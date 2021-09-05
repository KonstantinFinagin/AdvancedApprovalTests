using System;
using System.Collections.Generic;
using AdvancedApprovalTests.Domain;

namespace AdvancedApprovalTests.BL.Services
{
    public class TaxRateService : ITaxRateService
    {
        public IEnumerable<TaxRate> GetTaxRates(ETaxType taxType)
        {
            return taxType switch
            {
                ETaxType.Flat => new List<TaxRate> { new TaxRate { Id = 1, Rate = 0.13m } },
                _ => throw new ArgumentOutOfRangeException(nameof(taxType), taxType, null)
            };
        }
    }
}
