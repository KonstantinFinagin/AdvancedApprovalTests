using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedApprovalTests.DAL.Repositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
    }
}