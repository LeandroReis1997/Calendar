using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using api.calendar.Info.SqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.calendar.Dal
{
    public class UserAdminDal : IUserAdminDal
    {
        private SqlDbContext _sqlDbContext;

        public UserAdminDal(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<UserAdmin> AddUsers(UserAdmin user)
        {
            _sqlDbContext.Add(user);
            await _sqlDbContext.SaveChangesAsync();
            return user;
        }

        public Guid DeleteUsers(Guid userIdentity)
        {
            var entity = _sqlDbContext.UserAdmin.FirstOrDefault(x => x.UserIdentity.Equals(userIdentity));
            _sqlDbContext.Remove(entity);
            _sqlDbContext.SaveChanges();

            return userIdentity;
        }

        public async Task<UserAdmin> EditUsers(Guid userIdentity, UserAdmin user)
        {
            _sqlDbContext.UserAdmin.Update(user);
            await _sqlDbContext.SaveChangesAsync();
            return user;
        }

        public Task<UserAdmin> EditUsers(UserAdmin user)
        {
            throw new NotImplementedException();
        }

        public List<UserAdmin> GetAllUsers() =>
            _sqlDbContext.UserAdmin.ToList();
        public UserAdmin GetByEmail(string email) =>
            _sqlDbContext.UserAdmin.FirstOrDefault(x => x.Email == email);

        public UserAdmin GetByUsersIdentity(Guid userIdentity) =>
            _sqlDbContext.UserAdmin.FirstOrDefault(x => x.UserIdentity == userIdentity);
    }
}
