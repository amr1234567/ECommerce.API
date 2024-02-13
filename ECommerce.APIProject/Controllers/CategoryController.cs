using ECommerce.Core.Constants;
using ECommerce.Core.DTO.ForDB;
using ECommerce.Core.DTO.ForEndUser;
using ECommerce.Core.Interfaces.IUseCases.ICategoryUseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGetCategoriesUseCase _getCategories;
        private readonly IGetCategoryByIdUseCase _getCategoryById;
        private readonly IGetCategoriesByFiltersUseCase _getCategoriesByFilters;
        private readonly IDeleteCategoryUseCase _deleteCategory;
        private readonly IUpdateCategoryUseCase _updateCategory;
        private readonly IAddCategoryUseCase _addCategory;

        public CategoryController(
            IGetCategoriesUseCase getCategories,
            IGetCategoryByIdUseCase getCategoryById,
            IGetCategoriesByFiltersUseCase getCategoriesByFilters,
            IDeleteCategoryUseCase deleteCategory,
            IUpdateCategoryUseCase updateCategory,
            IAddCategoryUseCase addCategory
            )
        {
            _getCategories = getCategories;
            _getCategoryById = getCategoryById;
            _getCategoriesByFilters = getCategoriesByFilters;
            _deleteCategory = deleteCategory;
            _updateCategory = updateCategory;
            _addCategory = addCategory;
        }

        // GET: api/<CategoryController>
        [HttpGet("categories")]
        public async Task<ActionResult<List<CategoryDtoOut>>> GetAllCategories()
        {
            var Categories =await _getCategories.Execute();
            if (Categories == null)
                return BadRequest("Categories is Empty");
            return Ok(Categories.ToList());
        }

        // GET api/<CategoryController>/5
        [HttpGet("category/{id}")]
        public async Task<ActionResult<CategoryDtoOut>> GetCategoryById(string id)
        {
            bool check = Guid.TryParse(id, out Guid categoryId);
            if (!check)
                return BadRequest("Wrong Input -Not Guid-");
            var category =await _getCategoryById.Execute(categoryId);
            if (category == null)
                return BadRequest(id + " Couldn't be found");
            return Ok(category);
        }

        [HttpGet("categories/filter")]
        public async Task<ActionResult<CategoryDtoOut>> GetCategories(
            [FromQuery]string name = "")
        {
            var categories = await _getCategoriesByFilters.Execute(
                c => c.Name.ToLower().Contains(name)||
                (c.Description != null && c.Description.ToLower().Contains(name))
                );
            if (categories == null)
                return Ok(new List<CategoryDtoOut>());
            return Ok(categories);
        }

        // POST api/<CategoryController>
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("Category")]
        public async Task<ActionResult> AddCategory([FromBody] CategoryDtoIn CategoryIn)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad Input");
            await _addCategory.Excute(CategoryIn);
            return Ok("Category Added Successfuly");
        }

        // PUT api/<CategoryController>/5
        [Authorize(Roles = Roles.Admin)]
        [HttpPut("category/{id}")]
        public async Task<ActionResult> UpdateCategory(string id, [FromBody] CategoryDtoForUpdate categoryIn)
        {
            bool check = Guid.TryParse(id, out Guid categoryId);
            if (!check)
                return BadRequest("Wrong Input -Not Guid-");
            var category = await _getCategoryById.Execute(categoryId);
            if (category == null)
                return BadRequest(id + " Couldn't be found");
            await _updateCategory.Execute(categoryIn, categoryId);
            return Ok($"Category with \"{id}\" has been updated");
        }

        // DELETE api/<CategoryController>/5
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("category/{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            bool check = Guid.TryParse(id, out Guid categoryId);
            if (!check)
                return BadRequest("Wrong Input -Not Guid-");
            var category = await _getCategoryById.Execute(categoryId);
            if (category == null)
                return BadRequest(id + " Couldn't be found");
            await _deleteCategory.Execute(categoryId);
            return Ok($"Category with \"{id}\" has been deleted");
        }
    }
}
