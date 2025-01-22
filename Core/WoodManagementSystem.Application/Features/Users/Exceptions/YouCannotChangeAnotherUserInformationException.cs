using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Users.Exceptions
{
    public class YouCannotChangeAnotherUserInformationException : BaseException
    {
        public YouCannotChangeAnotherUserInformationException() : base("Farklı bir kullanıcının bilgilerini değiştiremezsiniz!")
        {

        }
    }
}
