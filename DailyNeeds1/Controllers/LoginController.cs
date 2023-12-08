using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DailyNeeds1.DTO;
using DailyNeeds1.Repo;
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
    public class LoginController : ControllerBase
    {
        private UnitOfWork unitOfWork;
        private ILog _logger;

        public LoginController(UnitOfWork uw, ILog logger)
        {
            unitOfWork = uw;
            _logger = logger;
        }

        [HttpGet,Route("GetAllLogins")]
        [Authorize(Roles="1,4,10")]
        public IActionResult GetAllLogins()
        {
            var logins = unitOfWork.LoginImplObject.GetAll();
            return Ok(logins);
        }

        [HttpPost,Route("AddNewLogin")]
        [Authorize(Roles = "1,4,10")]
        public IActionResult AddNewLogin(LoginDTO login)
        {
            try
            {
                bool status = unitOfWork.LoginImplObject.Add(login);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(login);
                }
                else
                {
                    return BadRequest("Error in adding login");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                // throw;
            }
        }

        [HttpPut,Route("UpdateLogin/{id}")]
       [Authorize(Roles = "1,4,10")]
        public IActionResult UpdateLogin(int id, LoginDTO loginUpdate)
        {
            loginUpdate.LoginId = id;

            try
            {
                bool status = unitOfWork.LoginImplObject.Update(loginUpdate);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(loginUpdate);
                }
                else
                {
                    return BadRequest($"Login with ID {id} not found or update failed");
                }
            }
            catch (Exception ex) 
            {
                _logger.Error(ex.Message);
                //return StatusCode(500, ex.Message);
                return StatusCode(500, $"Error adding movie: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
                //throw;
            }
        }

        [HttpDelete,Route("DeleteLogin/{id}")]
        [Authorize(Roles = "1,4,10")]
        public IActionResult DeleteLogin(int id)
        {
            try
            {

                bool status = unitOfWork.LoginImplObject.Delete(id);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok($"Login with ID {id} deleted");
                }
                else
                {
                    return BadRequest($"Login with ID {id} not found or delete failed");
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
