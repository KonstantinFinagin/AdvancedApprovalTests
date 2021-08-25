using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedApprovalTests.Domain;

namespace AdvancedApprovalTests.DAL.Repositories
{
    public interface IIncomeRecordsRepository : IRepository<IncomeRecord>
    {
        public Task<IEnumerable<IncomeRecord>> GetFiltered(int year);
    }
}
