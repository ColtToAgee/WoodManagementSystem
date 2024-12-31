using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WoodManagementSystem.Application.Features.Users.Command.DeleteUser;
using WoodManagementSystem.Application.Features.Users.Command.UpdateUser;
using WoodManagementSystem.Application.Features.Users.Queries.GetAllUsers;

namespace WoodManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Sistemdeki tüm kullanıcıları getiren api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await mediator.Send(new GetAllUsersQueryRequest());
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Kullanıcı bilgilerini güncellemeyi sağlayan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Kullanıcı silme işlemini sağlayan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
