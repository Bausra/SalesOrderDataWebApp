using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesOrderDataWebApp.Server.Repositories.InterfaceImplementations;
using SalesOrderDataWebApp.Shared.Dto;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementsController : ControllerBase
    {
        private readonly IElementsRepository _elementsRepository;
        private readonly IMapper _mapper;
        public ElementsController(IElementsRepository elementsRepository, IMapper mapper)
        {
            _elementsRepository = elementsRepository;
            _mapper = mapper;
        }

        [HttpGet("{windowId}/windows")]
        public ActionResult<List<ElementDto>> GetElementsForWindow(int windowId)
        {
            List<Element> elements = _elementsRepository.GetElementsForWindow(windowId);

            var result = _mapper.Map<List<ElementDto>>(elements);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddElement(ElementDto element)
        {
            Element newElement = _mapper.Map<Element>(element);

            _elementsRepository.AddElement(newElement);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{elementId}")]
        public ActionResult DeleteElement(int elementId)
        {
            if (!_elementsRepository.Exists(elementId))
                return NotFound();

            _elementsRepository.RemoveElement(elementId);

            return NoContent();
        }

        [HttpGet("{elementId}")]
        public ActionResult<ElementDto> GetElement(int elementId)
        {
            if (!_elementsRepository.Exists(elementId))
                return NotFound();

            Element element = _elementsRepository.GetElement(elementId);

            var result = _mapper.Map<ElementDto>(element);

            return Ok(result);
        }

        [HttpPut]
        public ActionResult UpdateElement(ElementDto element)
        {
            if (!_elementsRepository.Exists(element.Id))
                return NotFound();

            Element updatedElement = _mapper.Map<Element>(element);

            _elementsRepository.UpdateElement(updatedElement);

            return NoContent();
        }

    }
}
