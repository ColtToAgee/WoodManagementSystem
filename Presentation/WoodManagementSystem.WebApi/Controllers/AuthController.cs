using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WoodManagementSystem.Application.Features.Auth.Command.AdminRegister;
using WoodManagementSystem.Application.Features.Auth.Command.Login;
using WoodManagementSystem.Application.Features.Auth.Command.RefreshToken;
using WoodManagementSystem.Application.Features.Auth.Command.Register;
using WoodManagementSystem.Application.Features.Auth.Command.Revoke;
using WoodManagementSystem.Application.Features.Auth.Command.RevokeAll;

namespace WoodManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        //[HttpPost]
        //public async Task<IActionResult> GenerateRefreshPasswordCode()

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AdminRegister(AdminRegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
