using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;

namespace OrderManagementSystem.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrderControllerV1 : ControllerBase
    {
        private IOrderRepository _orderRepository;
        private readonly ILogger<OrderControllerV1> _logger;

        public OrderControllerV1(IOrderRepository orderRepository, ILogger<OrderControllerV1> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet, Route("GetAllOrders")]
        public async Task<ActionResult> GetAllOrder()
        { 
            _logger.LogInformation("Fetching all orders at {Time}", DateTime.UtcNow);
            var orders = await _orderRepository.GetAllOrder();
            if (orders == null) return NotFound("Empty");
            return Ok(orders);
        }

        [HttpPost, Route("Add")]
        public async Task<ActionResult> Add([FromBody] Order orderdet)
        {
            _logger.LogInformation("Adding order {OrderId}", orderdet.Id);
            string orderid = await _orderRepository.Add(orderdet);
            return Ok("OrderId "+ orderid + " Successfully added.");
        }

        [HttpGet, Route("GetByCustomerId/{id}")]
        public async Task<ActionResult> GetByCustomerId(string id)
        {
            var order = await _orderRepository.GetByCustomerId(id);
            if (order == null) return NotFound("No orders found for customer id: " + id);
            return Ok(order);
        }

        [HttpGet, Route("GetById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null) return NotFound("No orders found for id: " + id);
            return Ok(order);
        }

        [HttpDelete, Route("Cancel/{id}")]
        public async Task<IActionResult> Cancel(string id)
        {
            _logger.LogWarning("Cancelling order {OrderId}", id);
            string resp = await _orderRepository.Cancel(id);
            return Ok(resp);
        }
    }
}
