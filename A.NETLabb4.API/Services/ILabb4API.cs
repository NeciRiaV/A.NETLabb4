using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.NETLabb4.API.Services
{
    public interface ILabb4API<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetAll(int id);
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
    }
}
