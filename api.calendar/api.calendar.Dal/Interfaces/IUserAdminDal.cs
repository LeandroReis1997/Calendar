using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Dal.Interfaces
{
    public interface IUserAdminDal
    {
        List<UserAdmin> GetAllUsers();
        UserAdmin GetByUsersIdentity(Guid userIdentity);
        UserAdmin GetByEmail(string email);
        Task<UserAdmin> AddUsers(UserAdmin user);
        Task<UserAdmin> EditUsers(UserAdmin user);
        Guid DeleteUsers(Guid userIdentity);
        UserAdmin Login(string email, string senha);
    }
}
