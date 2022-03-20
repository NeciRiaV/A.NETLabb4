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

        //ADD NEW HOBBY
        public async Task<UserHobby> Add(UserHobby newEntity)
        {
            var result = await _appContext.UserHobbies.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        //DETE HOBBY
        public async Task<UserHobby> Delete(int id)
        {
            var result = await _appContext.UserHobbies.FirstOrDefaultAsync(uh => uh.UserID == id);
            if (result != null)
            {
                _appContext.UserHobbies.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //GET ALL HOBBIES AND USERS
        public async Task<IEnumerable<UserHobby>> GetAll()
        {
            return await _appContext.UserHobbies.ToListAsync();
        }

        public async Task<UserHobby> GetAll(int id)
        {
            var GetAllHobbiesSingUse = (from UsHo in _appContext.UserHobbies
                                        join us in _appContext.Users on UsHo.UserID equals us.UserID
                                        join ho in _appContext.Hobbies on UsHo.HobbyID equals ho.HobbyID
                                        where UsHo.UserID == id
                                        select UsHo.User);
            if (GetAllHobbiesSingUse != null)
            {
                foreach (var item in GetAllHobbiesSingUse)
                {
                    var result = await _appContext.UserHobbies.FirstOrDefaultAsync(uh => uh.UserID == id);
                    return result;

                }
            }
            return null;
        }

        //GET SINGEL USER
        public async Task<UserHobby> GetSingel(int id)
        {
            return await _appContext.UserHobbies.FirstOrDefaultAsync(uh => uh.UserID == id);
        }

        //UPDATE USER AND HOBBY
        public async Task<UserHobby> Update(UserHobby Entity)
        {
            var result = await _appContext.UserHobbies.FirstOrDefaultAsync(uh => uh.UserID == Entity.UserID);
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

    }
}
