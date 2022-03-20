using A.NETLabb4.API.Model;
using A.NETLabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.NETLabb4.API.Services
{
    public class UserRepository : ILabb4API<User>
    {
        private AppDbContext _appContext;
        public UserRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _appContext.Users.ToListAsync();
        }

        public Task<User> Add(User newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetSingel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User Entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
