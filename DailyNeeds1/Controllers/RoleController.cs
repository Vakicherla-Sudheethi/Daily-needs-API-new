using DailyNeeds1.DTO;
using DailyNeeds1.Repo;
using DailyNeeds1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using log4net;

namespace DailyNeeds1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private UnitOfWork unitOfWork = null;
        private ILog _logger;

        public RoleController(UnitOfWork uw, ILog logger)
        {
            unitOfWork = uw;
            _logger = logger;
        }

        [HttpGet,Route("GetAllRoles")]
        //[Authorize]
        public IActionResult GetAllRoles()
        {
            return Ok(unitOfWork.RoleImplObject.GetAll());
        }

        [HttpPost,Route("AddNewRole")]
        //[Authorize]
        public IActionResult AddNewRole(RoleDTO roleNew)
        {
            try
            {
                bool status = unitOfWork.RoleImplObject.Add(roleNew);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(roleNew);
                }
                else
                {
                    return BadRequest("Error in adding Role");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpPut,Route("UpdateRole/{id}")]
        //[Authorize]
        public IActionResult UpdateRole(int id, RoleDTO roleUpdate)
        {
            roleUpdate.RoleId = id;

            try
            {
                bool status = unitOfWork.RoleImplObject.Update(roleUpdate);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(roleUpdate);
                }
                else
                {
                    return BadRequest($"Role with ID {id} not found or update failed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpDelete,Route("DeleteRole/{id}")]
        //[Authorize]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                bool status = unitOfWork.RoleImplObject.Delete(id);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok($"Role with ID {id} deleted");
                }
                else
                {
                    return BadRequest($"Role with ID {id} not found or delete failed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }
    }
}
