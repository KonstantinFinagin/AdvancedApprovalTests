using System;
using System.Collections.Generic;
using AdvancedApprovalTests.BL.Services.TaxCalculationStrategies;
using AdvancedApprovalTests.Contracts;

namespace AdvancedApprovalTests.BL.Services
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly ITaxRateService _taxRateService;
        private readonly ITaxCalculationStrategy _taxCalculationStrategy;

        public TaxCalculationService(ITaxRateService taxRateService, ITaxCalculationStrategy taxCalculationStrategy)
        {
            _taxRateService = taxRateService;
            _taxCalculationStrategy = taxCalculationStrategy;
        }

        public IEnumerable<TaxCalculationResponse> CalculateYearlyTax(List<long> customerIds, int year)
        {
            throw new NotImplementedException();
        }
    }
}
