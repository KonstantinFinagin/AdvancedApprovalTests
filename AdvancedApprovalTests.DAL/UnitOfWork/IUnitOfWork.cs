using AdvancedApprovalTests.DAL.Repositories;

namespace AdvancedApprovalTests.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IIncomeRecordsRepository IncomeRecordsRepository { get; set; }
    }
}
