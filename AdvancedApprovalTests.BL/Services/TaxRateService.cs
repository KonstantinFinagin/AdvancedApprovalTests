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
                ETaxType.Flat => new List<TaxRate> { new TaxRate { Id = 1, MinAmount = 0, MaxAmount = decimal.MaxValue, Rate = 0.13m } },
                ETaxType.Progressive => new List<TaxRate>
                {
                    new TaxRate { Id = 2, Rate = 0.00m, MinAmount = 0, MaxAmount = 1000 },
                    new TaxRate { Id = 3, Rate = 0.05m, MinAmount = 1001, MaxAmount = 5000 },
                    new TaxRate { Id = 4, Rate = 0.10m, MinAmount = 5001, MaxAmount = 20000 },
                    new TaxRate { Id = 5, Rate = 0.20m, MinAmount = 20001, MaxAmount = 100000 },
                    new TaxRate { Id = 5, Rate = 0.35m, MinAmount = 100001, MaxAmount = decimal.MaxValue },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(taxType), taxType, null)
            };
        }
    }
}
