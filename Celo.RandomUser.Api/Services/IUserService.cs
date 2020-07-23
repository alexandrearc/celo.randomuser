using System.Collections.Generic;
using System.Threading.Tasks;
using Celo.RandomUser.Data;
using Celo.RandomUser.Requests;

namespace Celo.RandomUser.Services
{
    public interface IUserService
    {
        IEnumerable<User> List(ListRequest request);
        Task<User> GetAsync(int id);
        Task<User> UpdateAsync(User user);
        Task<User> CreateAsync();
        void Delete(int id);
    }
}
