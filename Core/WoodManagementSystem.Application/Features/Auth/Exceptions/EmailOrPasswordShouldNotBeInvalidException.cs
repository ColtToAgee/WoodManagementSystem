using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Email Yada Şifrenizi Kontrol Ediniz !!!") { }
    }
}
