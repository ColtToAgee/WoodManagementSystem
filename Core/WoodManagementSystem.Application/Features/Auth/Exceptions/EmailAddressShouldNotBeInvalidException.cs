using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldNotBeInvalidException : BaseException
    {
        public EmailAddressShouldNotBeInvalidException() : base("Email adresinizde hata bulunmaktadır !!!") { }
    }
}
