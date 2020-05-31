



using DataBase.Entities;
using Shared.DataAccessLayer;
using Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Users.DataAccessLayer
{
    public interface IUserDetailDAL : ICRUDOperationsDAL<UserDetail>
    {
        Task<List<UserDetail>> GetAllUser(DataSource dataSource);
        int Test();

    }
}
