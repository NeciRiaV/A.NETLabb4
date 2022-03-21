using A.NETLabb4.API.Model;
using A.NETLabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.NETLabb4.API.Services
{
    public class UserHobbyRepository : ILabb4API<UserHobby>
    {
        private AppDbContext _appContext;
        public UserHobbyRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        //GET ALL HOBBIES AND USERS
        public async Task<IEnumerable<UserHobby>> GetAll()
        {
            return await _appContext.UserHobbies.ToListAsync();
        }

        //GET ALL HOBBIES FOR SINGEL USER
        public async Task<IEnumerable<UserHobby>> GetSingelUser(int id)
        {
            IQueryable<UserHobby> quer = _appContext.UserHobbies;
            if (!quer.Equals(id))
            {
                quer = quer.Where(uh => uh.UserID == id);
            }
            return quer.ToList();
        }

        //GET ALL LINKS FOR SINGEL USER
        public async Task<IEnumerable<UserHobby>> GetLinks(int id)
        {
            IQueryable<UserHobby> quer = _appContext.UserHobbies;
            if (!quer.Equals(id))
            {
                quer = quer.Where(uh => uh.UserID == id);
            }
            return quer.ToList();
        }


    //ADD NEW HOBBY FOR SINGEL USER
    public async Task<UserHobby> Add(UserHobby newEntity)
    {
        var result = await _appContext.UserHobbies.AddAsync(newEntity);
        await _appContext.SaveChangesAsync();
        return result.Entity;
    }

    //UPDATE USER AND HOBBY
    public async Task<UserHobby> Update(UserHobby Entity)
    {
        var result = await _appContext.UserHobbies.FirstOrDefaultAsync(uh => uh.UserHobbyID == Entity.UserHobbyID);
        if (result != null)
        {
            result.UserID = Entity.UserID;
            result.HobbyID = Entity.HobbyID;
            result.WebsiteLink = Entity.WebsiteLink;

            await _appContext.SaveChangesAsync();
            return result;
        }
        return null;
    }

        public async Task<UserHobby> GetSingel(int id)
        {
            return await _appContext.UserHobbies.FirstOrDefaultAsync(uh => uh.UserHobbyID == id);
        }

    }
}
