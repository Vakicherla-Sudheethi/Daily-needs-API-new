using DailyNeeds1.DTO;
using DailyNeeds1.Repo;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;
using DailyNeeds1.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using log4net;

namespace DailyNeeds1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        UnitOfWork unitOfWork = null;
        ILog _logger;
        public CityController(UnitOfWork uw, ILog logger)
        {
            unitOfWork = uw;
            _logger = logger;

        }
        [HttpGet,Route("GetAllCities")]
        [Authorize(Roles = "4,1,10")]
        public IActionResult GetAllCities()
        {
            return Ok(unitOfWork.CityImplObject.GetAll());
        }

        [HttpPost,Route("AddNewCity")]
        [Authorize(Roles = "4")]
        public IActionResult AddNewCity(CityDTO cityNew)
        {
            try
            {

                bool Status = unitOfWork.CityImplObject.Add(cityNew);
                if (Status)
                {
                    unitOfWork.SaveAll();
                    return Ok(cityNew);
                }
                else
                {
                    return BadRequest("Error In Adding Role");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }
        [HttpPut,Route("UpdateCity/{id}")]
        [Authorize(Roles = "4")]
        public IActionResult UpdateCity(int id, CityDTO cityUpdate)
        {
            cityUpdate.CityId = id;

            try
            {
                bool status = unitOfWork.CityImplObject.Update(cityUpdate);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(cityUpdate);
                }
                else
                {
                    return BadRequest($"City with ID {id} not found or update failed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpDelete,Route("DeleteCity/{id}")]
        [Authorize(Roles = "4")]
        public IActionResult DeleteCity(int id)
        {
            try
            {
                bool status = unitOfWork.CityImplObject.Delete(id);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok($"City with ID {id} deleted");
                }
                else
                {
                    return BadRequest($"City with ID {id} not found or delete failed");
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