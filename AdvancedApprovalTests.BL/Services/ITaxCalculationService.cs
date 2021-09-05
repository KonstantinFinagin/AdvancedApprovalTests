using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedApprovalTests.Contracts;
using AdvancedApprovalTests.Domain;

namespace AdvancedApprovalTests.BL.Services
{
    public interface ITaxCalculationService
    {
        public Task<IEnumerable<TaxCalculationResponse>> CalculateYearlyTaxAsync(List<long> customerIds, int year,
            ETaxType type);
    }
}