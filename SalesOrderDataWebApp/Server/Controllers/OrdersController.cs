using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations;
using SalesOrderDataWebApp.Shared.Dto;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IWindowsRepository _windowsRepository;
        private readonly IElementsRepository _elementsRepository;
        private readonly IMapper _mapper;
        public OrdersController(IOrdersRepository ordersRepository, IWindowsRepository windowsRepository, IElementsRepository elementsRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _windowsRepository = windowsRepository;
            _elementsRepository = elementsRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<OrderDto>> GetOrders()
        {
            List<Order> orders = _ordersRepository.GetAllOrders();

            var result = _mapper.Map<List<OrderDto>>(orders);

            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public ActionResult<OrderDto> GetOrder(int orderId)
        {
            if (!_ordersRepository.Exists(orderId))
                return NotFound();

            Order order = _ordersRepository.GetOrder(orderId);

            var result = _mapper.Map<OrderDto>(order);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddOrder(OrderDto order)
        {
            Order newOrder = _mapper.Map<Order>(order);

            _ordersRepository.AddOrder(newOrder);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{orderId}")]
        public ActionResult DeleteOrder(int orderId)
        {
            if (!_ordersRepository.Exists(orderId))
                return NotFound();

            List<Window> windowsForOrder = _windowsRepository.GetWindowsForOrder(orderId);

            if (windowsForOrder.Any())
            {
                windowsForOrder.ForEach(window =>
                {
                    List<Element> windowElements = _elementsRepository.GetElementsForWindow(window.Id);

                    if (windowElements.Any())
                    {
                        windowElements.ForEach(element => _elementsRepository.RemoveElement(element.Id));
                    }

                    _windowsRepository.RemoveWindow(window.Id);
                });
            }

            _ordersRepository.RemoveOrder(orderId);

            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateOrder(OrderDto order)
        {
            if (!_ordersRepository.Exists(order.Id))       
                return NotFound();

            Order updatedOrder = _mapper.Map<Order>(order);

            _ordersRepository.UpdateOrder(updatedOrder);

            return NoContent();
        }
    }
}
