using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WoodManagementSystem.Application.Features.Orders.Command.CreateOrder;
using WoodManagementSystem.Application.Features.Orders.Command.DeleteOrder;
using WoodManagementSystem.Application.Features.Orders.Queries.GetAllOrders;
using WoodManagementSystem.Application.Features.Orders.Queries.GetCustomerOrders;

namespace WoodManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Sipariş işlemini oluşturan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Siparişin iptalini sağlayan api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> DeleteOrder(DeleteOrderCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Müşterinin tüm siparişlerini getiren api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetCustomerOrders(GetCustomerOrdersQueryRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Tüm müşterilerin siparişlerini getiren api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllOrders(GetAllOrdersQueryRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
