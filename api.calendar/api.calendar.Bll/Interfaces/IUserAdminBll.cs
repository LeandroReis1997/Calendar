using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Bll.Interfaces
{
    public interface IUserAdminBll
    {
        List<UserAdmin> GetAllUsers();
        UserAdmin GetByUsersIdentity(Guid userIdentity);
        UserAdmin GetByEmail(string email);
        Task<UserAdmin> AddUsers(UserAdmin user);
        Task<UserAdmin> EditUsers(Guid usersIdentity, UserAdmin user);
        Guid DeleteUsers(Guid userIdentity);
        UserAdmin Login(string Email, string Senha);
    }
}
