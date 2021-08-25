using System.Collections.Generic;

namespace AdvancedApprovalTests.Contracts
{
    public class TaxCalculationResponse
    {
        public long EmployeeId { get; set; }

        public IEnumerable<(decimal Basis, decimal Tax)> CalculatedTax { get; set; }
    }
}
