using System;

namespace AdvancedApprovalTests.Domain
{
    public class IncomeRecord
    {
        public long Id { get; set; }

        public long EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
