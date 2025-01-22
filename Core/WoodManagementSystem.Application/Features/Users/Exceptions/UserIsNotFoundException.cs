using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Users.Exceptions
{
    public class UserIsNotFoundException : BaseException
    {
        public UserIsNotFoundException() : base("Kullanıcı Bulunamadı")
        {

        }
    }
}
