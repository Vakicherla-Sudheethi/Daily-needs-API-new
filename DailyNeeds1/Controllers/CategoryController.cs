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
    public class CategoryController : ControllerBase
    {
        UnitOfWork unitOfWork; 
        ILog _logger;

        public CategoryController(UnitOfWork uw,ILog logger)
        {
            unitOfWork = uw;
            _logger = logger;   
        }

        [HttpGet,Route("GetAllCategories")]
        [Authorize(Roles ="4,1,10")]
        public IActionResult GetAllCategories()
        {
            var categories = unitOfWork.CategoryImplObject.GetAll();
            return Ok(categories);
        }

        [HttpPost,Route("AddNewCategory")]
        [Authorize(Roles ="4,10")]
        public IActionResult AddNewCategory(CategoryDTO category)
        {
            try
            {
                bool status = unitOfWork.CategoryImplObject.Add(category);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(category);
                }
                else
                {
                    return BadRequest("Error in adding category");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);

                //throw;
            }
        }

        [HttpPut,Route("AddNewCategory/{id}")]
        [Authorize(Roles ="4,10")]
        public IActionResult UpdateCategory(int id, CategoryDTO categoryUpdate)
        {
            categoryUpdate.CategoryID = id;

            try
            {
                bool status = unitOfWork.CategoryImplObject.Update(categoryUpdate);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(categoryUpdate);
                }
                else
                {
                    return BadRequest($"Category with ID {id} not found or update failed");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpDelete,Route("DeleteCategory/{id}")]
        [Authorize(Roles ="4,10")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                bool status = unitOfWork.CategoryImplObject.Delete(id);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok($"Category with ID {id} deleted");
                }
                else
                {
                    return BadRequest($"Category with ID {id} not found or delete failed");
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
