using WoodManagementSystem.Application.Bases;
using WoodManagementSystem.Application.Features.Users.Exceptions;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Users.Rules
{
    public class UserRules : BaseRules
    {
        public Task UserIsNotFound(User user)
        {
            if (user is null) throw new UserIsNotFoundException();
            return Task.CompletedTask;
        }
    }
}
