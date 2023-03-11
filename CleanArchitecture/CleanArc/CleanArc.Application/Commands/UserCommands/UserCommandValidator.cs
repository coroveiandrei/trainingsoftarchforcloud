using FluentValidation;
using CleanArc.Common.Errors;
using CleanArc.Common.Localization;
using CleanArc.Common.Extensions;
using System;
using CleanArc.Application.Interfaces.Authentication;

namespace CleanArc.Application.Commands.UserCommands
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserService _userService;
        public RegisterUserCommandValidator(IUserService userService, Ii18nService i18nService)
        {
            _userService = userService;
            RuleFor(x => x.User.Email).Must(BeNotNullOrEmptyString).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.STRING_CANNOT_BENULL_OR_EMPTY), "Email"));
            RuleFor(x => x.User.Email).EmailAddress().WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.INVALID_EMAIL_ADDRESS), "Email"));
            RuleFor(x => x.User.Email).Must(BeUniqueEmail).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.INVALID_EMAIL_ADDRESS), "Email"));
            RuleFor(x => x.User.Username).Must(BeNotNullOrEmptyString).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.STRING_CANNOT_BENULL_OR_EMPTY), "Username"));
            RuleFor(x => x.User.Username).Must(BeUniqueUsername).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_ENTITY), "Username"));
            RuleFor(x => x.User.Password).MinimumLength(8).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.PASSWORD_TOO_SHORT)));
            RuleFor(x => x.User.Password).Must(t => t.MatchPasswordComplexity()).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.PASSWORD_DOES_NOT_MATCH_COMPLEXITY)));
        }

        private bool BeUniqueEmail(string email)
        {
            return _userService.IsEmailUnique(email);
        }

        private bool BeNotNullOrEmptyString(string arg)
        {
            return !string.IsNullOrEmpty(arg);
        }

        public bool BeUniqueUsername(string username)
        {
            return _userService.IsUsernameUnique(username);
        }
    }

    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator(Ii18nService i18nService)
        {
            RuleFor(x => x.NewPassword).MinimumLength(6).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.PASSWORD_TOO_SHORT)));
            RuleFor(x => x.NewPassword).Must(t => t.MatchPasswordComplexity()).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.PASSWORD_DOES_NOT_MATCH_COMPLEXITY)));
            RuleFor(x => x).Must(t => t.OldPassword != t.NewPassword).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.NEWPASSWORD_MUST_BE_DIFFERENT_THAN_OLD_PASSWORD)));
        }
    }

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IUserService _userService;
        public DeleteUserCommandValidator(IUserService userService, Ii18nService i18nService)
        {
            _userService = userService;
            RuleFor(x => x.UserId).Must(Exist).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.NOT_FOUND), "User"));
        }
        public bool Exist(Guid id)
        {
            return _userService.ExistsUser(id);
        }
    }
}
