using DailyNeeds1.DTO;
using DailyNeeds1.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using log4net;

namespace DailyNeeds1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private UnitOfWork unitOfWork;
        private ILog _logger;

        public OfferController(UnitOfWork uw, ILog logger)
        {
            unitOfWork = uw;
            _logger = logger;
        }

        [HttpGet,Route("GetAllOffers")]
        [Authorize(Roles = "4,10")]
        public IActionResult GetAllOffers()
        {
            return Ok(unitOfWork.OfferImplObject.GetAll());
        }

        [HttpPost,Route("AddNewOffer")]
        [Authorize(Roles = "4,10")]
        public IActionResult AddNewOffer(OfferDTO offerNew)
        {
            try
            {
                bool status = unitOfWork.OfferImplObject.Add(offerNew);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(offerNew);
                }
                else
                {
                    return BadRequest("Error in adding offer");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpPut,Route("UpdateOffer/{id}")]
        [Authorize(Roles = "4,10")]
        public IActionResult UpdateOffer(int id, OfferDTO offerUpdate)
        {
            offerUpdate.OfferId = id;

            try
            {
                bool status = unitOfWork.OfferImplObject.Update(offerUpdate);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(offerUpdate);
                }
                else
                {
                    return BadRequest($"Offer with ID {id} not found or update failed");
                }
            }
            catch (Exception  ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpDelete,Route("DeleteOffer/{id}")]
        [Authorize(Roles = "4,10")]
        public IActionResult DeleteOffer(int id)
        {
            try
            {
                bool status = unitOfWork.OfferImplObject.Delete(id);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok($"Offer with ID {id} deleted");
                }
                else
                {
                    return BadRequest($"Offer with ID {id} not found or delete failed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        //newly-added code
        [HttpGet, Route("GetAllProductOffers/{locationId}")] 
        [Authorize(Roles = "4,10,1")]
        public IActionResult GetAllProductOffers(int locationId)
        {
            try
            {
                var productOffers = unitOfWork.OfferImplObject.GetAllProductOffers(locationId);
                return Ok(productOffers);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
