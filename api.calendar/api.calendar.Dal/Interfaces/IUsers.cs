using api.calendar.Info.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.calendar.Dal.Interfaces
{
    public interface IUsers
    {
        List<User> GetAllUsers();
        User GetByUsersIdentity(int roomIdentity);
        User GetByEmail(string email);
        Task<User> AddUsers(User user);
        Task<User> EditUsers(int userIdentity, User user);
        int DeleteUsers(int userIdentity);
    }
}
