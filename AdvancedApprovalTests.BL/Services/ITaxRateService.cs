using System.Collections.Generic;
using AdvancedApprovalTests.Domain;

namespace AdvancedApprovalTests.BL.Services
{
    public interface ITaxRateService
    {
        public IEnumerable<TaxRate> GetTaxRates(ETaxType taxType);
    }
}
