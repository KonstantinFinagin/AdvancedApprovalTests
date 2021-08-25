using System.Collections.Generic;
using AdvancedApprovalTests.Contracts;

namespace AdvancedApprovalTests.BL.Services
{
    public interface ITaxCalculationService
    {
        public IEnumerable<TaxCalculationResponse> CalculateYearlyTax(List<long> customerIds, int year);
    }
}