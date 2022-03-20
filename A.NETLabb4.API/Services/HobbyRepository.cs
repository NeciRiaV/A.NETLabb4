using A.NETLabb4.API.Model;
using A.NETLabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.NETLabb4.API.Services
{
    public class HobbyRepository : ILabb4API<Hobby>
    {
        private AppDbContext _appContext;
        public HobbyRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<IEnumerable<Hobby>> GetAll()
        {
            return await _appContext.Hobbies.ToListAsync();
        }

        public Task<Hobby> Add(Hobby newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<Hobby> GetSingel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hobby> Update(Hobby Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Hobby> Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Hobby> ILabb4API<Hobby>.GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}
