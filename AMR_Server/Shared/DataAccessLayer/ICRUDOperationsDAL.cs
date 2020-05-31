using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataAccessLayer
{
    public interface ICRUDOperationsDAL<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task<long> Save(T entity);
        Task<long> Delete(long id);
    }
}
