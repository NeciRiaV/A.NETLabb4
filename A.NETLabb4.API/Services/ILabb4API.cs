using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.NETLabb4.API.Services
{
    public interface ILabb4API<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetSingelUser(int id);
        Task<IEnumerable<T>> GetLinks(int id);
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
    }
}
