using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpGet("GetAllOrderings")]
        public async Task<IActionResult> GetAllOrderings()
        {
            return Ok(await _mediator.Send(new GetOrderingQuery()));
        }

        [HttpGet("GetOrderingById")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            return Ok(await _mediator.Send(new GetOrderingByIdQuery(id)));
        }
        
        [HttpPost("CreateOrdering")]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla oluşturuldu.");
        }
        
        [HttpPut("UpdateOrdering")]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingRequest command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi.");
        }
        
        [HttpDelete("DeleteOrdering")]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new DeleteOrderingRequest(id));
            return Ok("Sipariş başarıyla silindi.");
        }
    }
}
