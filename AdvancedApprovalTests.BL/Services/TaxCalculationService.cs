using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedApprovalTests.Contracts;
using AdvancedApprovalTests.DAL.UnitOfWork;
using AdvancedApprovalTests.Domain;

namespace AdvancedApprovalTests.BL.Services
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly ITaxRateService _taxRateService;
        private readonly IUnitOfWork _uow;

        public TaxCalculationService(ITaxRateService taxRateService, IUnitOfWork uow)
        {
            _taxRateService = taxRateService;
            _uow = uow;
        }

        public async Task<IEnumerable<TaxCalculationResponse>> CalculateYearlyTaxAsync(List<long> customerIds, int year, ETaxType type)
        {
            var data = await _uow.IncomeRecordsRepository.GetFiltered(year);
            var customerDataRecords = data.GroupBy(d => d.EmployeeId);
            return customerDataRecords.Select(recordSet => GetCalculationResponse(recordSet, type));
        }

        private TaxCalculationResponse GetCalculationResponse(IEnumerable<IncomeRecord> incomeRecords, ETaxType type)
        {
            var taxRates = _taxRateService.GetTaxRates(type).OrderBy(r => r.MinAmount);
            var incomeSum = incomeRecords.Sum(r => r.Amount);

            var movingRemainder = incomeSum;

            var calculatedTax = new List<(decimal Basis, decimal Tax)>();

            foreach (var taxRate in taxRates)
            {
                var basis = taxRate.MaxAmount - taxRate.MinAmount;
                if (basis > movingRemainder)
                {
                    basis = movingRemainder;
                }

                movingRemainder -= basis;
                calculatedTax.Add((basis, basis * taxRate.Rate));
            }

            return new TaxCalculationResponse()
            {
                EmployeeId = incomeRecords.First().EmployeeId,
                CalculatedTax = calculatedTax,
                TotalTax = calculatedTax.Sum(t => t.Tax)
            };
        }
    }
}
