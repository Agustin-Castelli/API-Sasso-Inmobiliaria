using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SassoInmobiliariaAPI.Models.Entities;
using SassoInmobiliariaAPI.Models.Exceptions;
using SassoInmobiliariaAPI.Services.DTOs;
using SassoInmobiliariaAPI.Services.Interfaces;

namespace SassoInmobiliariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] PropRequest request)
        {
            try
            {
                var obj = _propertyService.Create(request);

                return Ok(obj);
            }
            catch (DuplicateElementException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PropRequest request)
        {
            try
            {
                _propertyService.Update(id, request);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return  NotFound(ex.Message);
            }
        }

        [HttpPatch("[action]/{id}")]
        public IActionResult DeleteProp([FromRoute] int id)
        {
            try
            {
                _propertyService.DeleteProp(id);
                return NoContent();
            }
            catch(NotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("[action]/{id}")]
        public IActionResult RecoverProp([FromRoute] int id)
        {
            try
            {
                _propertyService.RecoverProp(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<Property> GetById([FromRoute] int id)
        {
            try
            {
                return _propertyService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<Property>> GetActiveProperties()
        {
            return _propertyService.GetActiveProperties();
        }

        [HttpGet("[action]")]
        public ActionResult<List<Property>> GetAll()
        {
            return _propertyService.GetAll();
        }
    }
}
