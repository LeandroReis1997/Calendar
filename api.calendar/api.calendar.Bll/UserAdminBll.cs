using api.calendar.Bll.Interfaces;
using api.calendar.Dal.Interfaces;
using api.calendar.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace api.calendar.Bll
{
    public class UserAdminBll : IUserAdminBll
    {
        private IUserAdminDal _userAdminDal;

        public UserAdminBll(IUserAdminDal userAdminDal)
        {
            _userAdminDal = userAdminDal;
        }

        public async Task<UserAdmin> AddUsers(UserAdmin user)
        {
            try
            {
                var emailExist = _userAdminDal.GetByEmail(user.Email);
                if (emailExist.Email != null)
                    throw new BusinessException("Email já cadastrado.");

                return await _userAdminDal.AddUsers(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid DeleteUsers(Guid userIdentity)
        {
            return _userAdminDal.DeleteUsers(userIdentity);
        }

        public async Task<UserAdmin> EditUsers(Guid usersIdentity, UserAdmin user)
        {
            try
            {
                return await _userAdminDal.EditUsers(new UserAdmin
                {
                    UserIdentity = usersIdentity,
                    Name = user.Name,
                    Password = user.Password
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserAdmin> GetAllUsers() =>
            _userAdminDal.GetAllUsers();

        public UserAdmin GetByEmail(string email) =>
            _userAdminDal.GetByEmail(email);

        public UserAdmin GetByUsersIdentity(Guid userIdentity) =>
            _userAdminDal.GetByUsersIdentity(userIdentity);

        public UserAdmin Login(string email, string senha)
        {
            return _userAdminDal.Login(email, senha);
        }
    }
}
