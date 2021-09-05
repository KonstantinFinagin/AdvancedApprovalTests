using System;
using System.Collections.Generic;
using AdvancedApprovalTests.Contracts;
using AdvancedApprovalTests.DAL.UnitOfWork;

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

        public IEnumerable<TaxCalculationResponse> CalculateYearlyTax(List<long> customerIds, int year)
        {
            throw new NotImplementedException();
        }
    }
}
