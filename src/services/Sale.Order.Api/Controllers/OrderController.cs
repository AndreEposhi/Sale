using Microsoft.AspNetCore.Mvc;
using Sale.Core.Controller;
using Sale.Order.Application.Order.Command;
using Sale.Order.Application.Order.Services;
using System.Threading.Tasks;

namespace Sale.Order.Api.Controllers
{
    [Route("api/order")]
    public class OrderController : MainController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(AddOrderCommand command)
            => CustomResponse(await _orderService.AddOrder(command));
    }
}