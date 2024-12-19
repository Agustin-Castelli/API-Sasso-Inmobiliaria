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
    public class DevPropController : ControllerBase
    {
        private readonly IDevelopPropService _developPropService;

        public DevPropController(IDevelopPropService developPropService)
        {
            _developPropService = developPropService;
        }

        //  <-------------------------->  CONTROLADORES RELACIONADOS AL CRUD  <-------------------------->

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] DevPropRequest request)
        {
            try
            {
                var obj = _developPropService.Create(request);
                return Ok(obj);
            }

            catch (DuplicateElementException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] DevPropRequest request)
        {
            try
            {
                _developPropService.Update(id, request);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("[action]/{id}")]
        public IActionResult DeleteDevProp([FromRoute] int id)
        {
            try
            {
                _developPropService.DeleteDevProp(id);
                return NoContent();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("[action]/{id}")]
        public IActionResult RecoverDevProp([FromRoute] int id)
        {
            try
            {
                _developPropService.RecoverDevProp(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<DevelopmentProp> GetById(int id)
        {
            try
            {
                return _developPropService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<DevelopmentProp>> GetActiveDevProp()
        {
            return _developPropService.GetActiveDevProps();
        }

        [HttpGet("[action]")]
        public ActionResult<List<DevelopmentProp>> GetAll()
        {
            return _developPropService.GetAll();
        }


        //  <-------------------------->  CONTROLADORES ESPECÍFICOS DE LA ENTIDAD <-------------------------->


        [HttpPatch("[action]/{devId}/{propId}")]
        public IActionResult AddPropToDevelopment([FromRoute] int devId, [FromRoute] int propId)
        {
            try
            {
                _developPropService.AddPropToDevelopment(devId, propId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("[action]/{devId}/{propId}")]
        public IActionResult RemovePropFromDevelopment([FromRoute] int devId, [FromRoute] int propId)
        {
            try
            {
                _developPropService.RemovePropFromDevelopment(devId, propId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public List<DevelopmentProp> GetAllDevProps()
        {
            return _developPropService.GetAllDevProps();
        }
    }
}
