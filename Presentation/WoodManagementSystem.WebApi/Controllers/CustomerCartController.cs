using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WoodManagementSystem.Application.Features.Carts.Command.AddCartItem;
using WoodManagementSystem.Application.Features.Carts.Command.DeleteCartItem;
using WoodManagementSystem.Application.Features.Carts.Command.UpdateCartItem;
using WoodManagementSystem.Application.Features.Carts.Queries.GetCustomerCart;
using WoodManagementSystem.Application.Features.Carts.Queries.GetTemplateCustomerCart;

namespace WoodManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCartController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerCartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Müşteri sepetindeki verileri getiren api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetCustomerCart(GetCustomerCartQueryRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Müşteri sepetine ürün ekleme işlemi yapan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> AddCustomerCartItem(AddCartItemCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Müşteri sepetindeki ürünü güncelleme işlemi yapan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> UpdateCustomerCartItem(UpdateCartItemCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Müşteri sepetindeki ürünü silme işlemi yapan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> DeleteCustomerCartItem(DeleteCartItemCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> GetTemplateCustomerCart(GetTemplateCustomerCartQueryRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
