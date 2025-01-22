using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WoodManagementSystem.Application.Features.Patterns.Command.CreatePattern;
using WoodManagementSystem.Application.Features.Patterns.Command.DeletePattern;
using WoodManagementSystem.Application.Features.Patterns.Command.UpdatePattern;
using WoodManagementSystem.Application.Features.Patterns.Queries.GetAllPatterns;

namespace WoodManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatternController : ControllerBase
    {
        private readonly IMediator mediator;

        public PatternController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Tüm kalıpları getiren api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="admin,user")]
        public async Task<IActionResult> GetAllPatterns()
        {
            var response = await mediator.Send(new GetAllPatternsQueryRequest());
            return StatusCode(StatusCodes.Status200OK,response);
        }

        /// <summary>
        /// Yeni kalıp oluşturma işlemi sağlayan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreatePattern(CreatePatternCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Kalıp güncelleme işlemi yapmayı sağlayan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdatePattern(UpdatePatternCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Kalıp silme işlemi yapmayı sağlayan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletePattern(DeletePatternCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
