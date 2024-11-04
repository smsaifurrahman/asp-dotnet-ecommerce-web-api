using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_dotnet_ecommerce_web_api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace asp_dotnet_ecommerce_web_api.Models.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();
        // GET: /api/categories => Read categories
        [HttpGet]
        public IActionResult GetCategories([FromQuery] string searchValue = "")
        {
            // if (searchValue != null)
            // {
            //     var searchedCategories = categories.Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();

            //     return Ok(searchedCategories);

            // }

            var categoryList = categories.Select(c => new CategoryReadDto{
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            }).ToList();
  
            return Ok(categories);
        }
        // POST: /api/categories => create a categories
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryCreateDto categoryData)
        {
            if (string.IsNullOrEmpty(categoryData.Name))
            {
                return BadRequest("Category Name is required and can not be empty");
            }
            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = categoryData.Name,
                Description = categoryData.Description,
                CreatedAt = DateTime.UtcNow,

            };
            categories.Add(newCategory);
            var categoryReadDto = new CategoryReadDto {
                CategoryId = newCategory.CategoryId,
                Name = newCategory.Name,
                Description = newCategory.Description,
                CreatedAt = newCategory.CreatedAt
                };


            return Created($"/api/categories/{newCategory.CategoryId}", categoryReadDto);

        }
        // PUT: /api/categories/{categoryId} => update category by Id
        [HttpPut("{categoryId:guid}")]
        public IActionResult UpdateCategoryById(Guid categoryId, [FromBody] CategoryUpdateDto categoryData)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);

            if (foundCategory == null)
            {
                return NotFound("Category with this Id does not exit");
            }
            if (categoryData == null)
            {
                return NotFound("Category data is missing");
            }

            if (!string.IsNullOrEmpty(categoryData.Name))
            {
                foundCategory.Name = categoryData.Name ?? foundCategory.Name;
            }
            if (!string.IsNullOrEmpty(categoryData.Description))
            {
                foundCategory.Description = categoryData.Description ?? foundCategory.Description;
            }
            return NoContent();


        }
        // DELETE: /api/categories/{categoryId} => Delete a category by ID
        [HttpDelete("{categoryId:guid}")]
        public IActionResult DeleteCategoryById(Guid categoryId)
        {
            var foundCategory = categories.FirstOrDefault(category => category.CategoryId == categoryId);

            if (foundCategory == null)
            {
                return NotFound("Category with this Id does not exit");
            }

            return NoContent();


        }
    }
}