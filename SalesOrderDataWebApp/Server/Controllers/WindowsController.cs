using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations;
using SalesOrderDataWebApp.Shared.Dto;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WindowsController : ControllerBase
    {
        private readonly IWindowsRepository _windowsRepository;
        private readonly IElementsRepository _elementsRepository;
        private readonly IMapper _mapper;
        public WindowsController(IWindowsRepository windowsRepository, IElementsRepository elementsRepository, IMapper mapper)
        {
            _windowsRepository = windowsRepository;
            _elementsRepository = elementsRepository;
            _mapper = mapper;
        }

        [HttpGet("{orderId}/orders")]
        public ActionResult<List<WindowDto>> GetWindowsForOrder(int orderId)
        {
            List<Window> windows = _windowsRepository.GetWindowsForOrder(orderId);

            var result = _mapper.Map<List<WindowDto>>(windows);

            return Ok(result);
        }

        [HttpGet("{windowId}")]
        public ActionResult<WindowDto> GetWindow(int windowId)
        {
            if (!_windowsRepository.Exists(windowId))
                return NotFound();

            Window window = _windowsRepository.GetWindow(windowId);

            var result = _mapper.Map<WindowDto>(window);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddWindow(WindowDto window)
        {
            Window newWindow = _mapper.Map<Window>(window);

            _windowsRepository.AddWindow(newWindow);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public ActionResult UpdateWindow(WindowDto window)
        {
            if (!_windowsRepository.Exists(window.Id))
                return NotFound();

            Window updatedWindow = _mapper.Map<Window>(window);

            _windowsRepository.UpdateWindow(updatedWindow);

            return NoContent();
        }

        [HttpDelete("{windowId}")]
        public ActionResult DeleteWindow(int windowId)
        {
            if (!_windowsRepository.Exists(windowId))
                return NotFound();

            List<Element> elementsForWindow = _elementsRepository.GetElementsForWindow(windowId);
            if (elementsForWindow.Any())
                elementsForWindow.ForEach(element => _elementsRepository.RemoveElement(element.Id));

            _windowsRepository.RemoveWindow(windowId);

            return NoContent();
        }
    }
}
