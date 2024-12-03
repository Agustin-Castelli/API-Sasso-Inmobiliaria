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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] AdminRequest request)
        {
            try
            {
                var obj = _adminService.Create(request);

                return Ok(obj);
            }
            catch (DuplicateElementException ex)
            {
                return Conflict(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _adminService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] AdminRequest request)
        {
            try
            {
                _adminService.Update(id, request);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<Admin> GetById(int id)
        {
            try
            {
                return _adminService.GetById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public ActionResult<List<Admin>> GetAll()
        {
            return _adminService.GetAll();
        }
    }
}
