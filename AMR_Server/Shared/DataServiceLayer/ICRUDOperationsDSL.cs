
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataServiceLayer
{
    public interface ICRUDOperationsDSL<T>
    {
        //Task<Response> GetAll(DataSource dataSource);
        //Task<ResponseEntityList<T>> GetAllLite();
        Task<T> GetById(long id);
        Task<long> Save(T entity);
        Task<long> Delete(long id);
    }
}
