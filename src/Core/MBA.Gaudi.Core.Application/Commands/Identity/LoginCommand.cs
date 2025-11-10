using FluentValidation.Results;
using MediatR;
using MBA.Gaudi.Core.Application.DTOs;
using MBA.Gaudi.Core.Application.Validators.Identity;

namespace MBA.Gaudi.Core.Application.Commands.Identity
{
    public class LoginCommand : IRequest<LoginResultDto>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public LoginResultDto Result { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public LoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public void SetResult(LoginResultDto result)
        {
            Result = result;
        }

        public bool IsValid()
        {
            ValidationResult = new LoginCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

