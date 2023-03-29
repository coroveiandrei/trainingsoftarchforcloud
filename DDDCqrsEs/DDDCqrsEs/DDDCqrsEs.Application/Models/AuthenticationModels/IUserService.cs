using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCqrsEs.Application.Models.AuthenticationModels
{
    public interface IUserService
    {
        UserModel SignIn(string email, string password);
        void SignOut();
        UserModel Register(RegisterUserModel user);
        void DeleteUser(Guid id);
        bool ChangePassword(string email, string oldPassword, string newPassword);

        List<UserModel> GetUsers();
        bool ExistsUser(Guid id);
        bool IsUsernameUnique(string username);
        bool IsEmailUnique(string email);
        UserModel GetUsersById(Guid id);
    }
}
