using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("Böyle Bir Kullanıcı Zaten Bulunmaktadır !!!") { }
    }
}
