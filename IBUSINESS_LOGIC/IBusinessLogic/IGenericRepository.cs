using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS;


namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<RETURN_MESSAGE> AddAsync(T entity);
        Task<RETURN_MESSAGE> UpdateAsync(T entity);
        Task<RETURN_MESSAGE> DeleteAsync(T entity);
    }
}
