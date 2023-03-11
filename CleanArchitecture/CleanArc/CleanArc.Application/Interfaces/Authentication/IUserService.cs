using CleanArc.Application.Models.AuthenticationModels;
using System;
using System.Collections.Generic;

namespace CleanArc.Application.Interfaces.Authentication
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
