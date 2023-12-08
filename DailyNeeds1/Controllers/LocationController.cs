using DailyNeeds1.DTO;
using DailyNeeds1.Repo;
using DailyNeeds1.DTO;
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
    public class LocationController : ControllerBase
    {

        UnitOfWork unitOfWork = null;
        ILog _logger;

        public LocationController(UnitOfWork uw, ILog logger)
        {
            unitOfWork = uw;
            _logger = logger;

        }
        [HttpGet,Route("GetAllLocations")]
        [Authorize(Roles ="4,1,10")]
        public IActionResult GetAllLocations()
        {
            return Ok(unitOfWork.LocationImplObject.GetAll());
        }

        [HttpPost,Route("AddNewLocation")]
        [Authorize(Roles ="4")]
        public IActionResult AddNewLocation(LocationDTO locNew)
        {
            try
            {
                bool Status = unitOfWork.LocationImplObject.Add(locNew);
                if (Status)
                {
                    unitOfWork.SaveAll();
                    return Ok(locNew);
                }
                else
                {
                    return BadRequest("Error In Adding User");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }
        [HttpPut,Route("UpdateLocation/{id}")]
        [Authorize(Roles ="4")]
        public IActionResult UpdateLocation(int id, LocationDTO locationUpdate)
        {
            locationUpdate.LocId = id;

            try
            {
                bool status = unitOfWork.LocationImplObject.Update(locationUpdate);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(locationUpdate);
                }
                else
                {
                    return BadRequest($"Location with ID {id} not found or update failed");
                }
            }
            catch (Exception ex)
            {

                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpDelete,Route("DeleteLocation/{id}")]
        [Authorize(Roles = "4")]
        public IActionResult DeleteLocation(int id)
        {
            try
            {
                bool status = unitOfWork.LocationImplObject.Delete(id);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok($"Location with ID {id} deleted");
                }
                else
                {
                    return BadRequest($"Location with ID {id} not found or delete failed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        //newly-added
        [HttpGet, Route("GetLocationsByCityId/{cityId}")]
        [Authorize(Roles = "4,1,10")] 
        public IActionResult GetLocationsByCityId(int cityId)
        {
            try
            {
                var locations = unitOfWork.LocationImplObject.GetLocationsByCityId(cityId);

                if (locations != null && locations.Any())
                {
                    return Ok(locations);
                }
                else
                {
                    return NotFound($"No locations found for City ID {cityId}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

    }
}