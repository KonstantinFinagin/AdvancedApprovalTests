namespace AdvancedApprovalTests.Domain
{
    public class TaxRate
    {
        public long Id { get; set; }

        public decimal? MinAmount { get; set; }

        public decimal? MaxAmount { get; set; }

        public decimal Rate { get; set; }
    }
}
