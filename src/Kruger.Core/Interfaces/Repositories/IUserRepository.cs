using Kruger.Core.Entities;
using System.Threading.Tasks;

namespace Kruger.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByUserName(string userName);
    }
}
