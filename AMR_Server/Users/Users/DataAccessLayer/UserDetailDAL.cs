
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Users.DataAccessLayer
{
    public class UserDetailDAL : IUserDetailDAL
    {
        private AppDbContext _context;
        private DbSet<UserDetail> _entity;

        public UserDetailDAL(AppDbContext context)
        {
            this._context = context;
            this._entity = context.Set<UserDetail>();
        }

        public async Task<long> Save(UserDetail entity)
        {
            _context.Entry(entity).State = entity.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<long> Delete(long id)
        {
            UserDetail userDetail = await GetById(id);
            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<UserDetail>> GetAll()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetail> GetById(long id)
        {
            return await _context.UserDetails.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<UserDetail>> GetAllUser(DataSource dataSource)
        {
            List<UserDetail> lstUser = new List<UserDetail>();
            try
            {
                if (string.IsNullOrEmpty(dataSource.Keyword))
                {
                    lstUser = _context.UserDetails
                       .Skip((dataSource.PageNumber -1) * dataSource.PageSize).Take(dataSource.PageSize).ToList();
                }
                else
                {
                    lstUser = _context.UserDetails
                        .Where(x => x.Address.Contains(dataSource.Keyword) || x.UserName.Contains(dataSource.Keyword)
                        || x.EmailId.Contains(dataSource.Keyword) || x.MobileNo.Contains(dataSource.Keyword)
                        || x.PinCode.Contains(dataSource.Keyword))
                        .Take(dataSource.PageNumber * dataSource.PageSize).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Task.Run(() => lstUser);
        }

        public int Test()
        {
            return 2;
        }
    }
}
