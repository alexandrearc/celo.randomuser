using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celo.RandomUser.Data;
using Celo.RandomUser.Requests;
using Microsoft.EntityFrameworkCore;

namespace Celo.RandomUser.Services
{
    public class UserService : IUserService
    {
        private readonly RandomUserDbContext _db;
        private readonly IGeneratorService _generator;

        public UserService(RandomUserDbContext context, IGeneratorService generatorService)
        {
            _db = context;
            _generator = generatorService;
        }

        public void Delete(int id)
        {
            _db.Users.Remove(new User { Id = id });
        }

        public async Task<User> GetAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public IEnumerable<User> List(ListRequest request)
        {
            if (request.PageSize == 0 || request.PageSize > 100)
                request.PageSize = 50;

            if (string.IsNullOrEmpty(request.SearchTerm))
                return _db.Users.Take(request.PageSize);

            return _db.Users.Where(u => u.FirstName == request.SearchTerm || u.LastName == request.SearchTerm).Take(request.PageSize);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _db.Users.Attach(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> CreateAsync()
        {
            var user = _generator.CreateUser();
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
