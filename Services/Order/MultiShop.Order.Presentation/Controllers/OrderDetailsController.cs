using System.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderQueries;

namespace MultiShop.Order.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _deleteOrderDetailCommandHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler deleteOrderDetailCommandHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        }

        [HttpGet("GetAllOrderDetails")]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var result = await _getOrderDetailQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("GetOrderDetailById")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var result = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(result);
        }
        
        [HttpPost("CreateOrderDetail")]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş Detayı Başarıyla Eklendi.");
        }
        
        [HttpPut("UpdateOrderDetail")]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş Detayı Başarıyla Güncellendi.");
        }
        
        [HttpDelete("DeleteOrderDetail")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _deleteOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş Detayı Başarıyla Silindi.");
        }
    }
}
