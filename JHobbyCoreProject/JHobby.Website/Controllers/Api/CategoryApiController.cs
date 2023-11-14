using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JHobby.Website.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryApiController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryApiController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CategoryViewModel>> GetCategoriesAll()
		{
			var servicesDto = _categoryService.GetList();

			var viewModel = servicesDto.Select(dto => new CategoryViewModel
			{
				CategoryId = dto.CategoryId,
				CategoryName = dto.CategoryName,
				TypeName = dto.TypeName,
			});

			return Ok(viewModel);
		}

		[HttpGet("{id}")]
		public ActionResult<IEnumerable<CategoryViewModel>> GetCategoriesById(int id)
		{
			var servicesDto = _categoryService.GetDetail(id);

			if (servicesDto == null) { return NotFound(); }

			var viewModel = new CategoryViewModel
			{
				CategoryId = servicesDto.CategoryId,
				CategoryName = servicesDto.CategoryName,
				TypeName = servicesDto.TypeName
			};

			return Ok(viewModel);
		}

		[HttpPost]
		public IActionResult InsertCategory(CreateCategoryViewModel createCategoryViewModel)
		{
			var mapper = new CreateCategoryModel
            {
				CategoryName = createCategoryViewModel.CategoryName,
				TypeName = createCategoryViewModel.TypeName
			};

			var result = _categoryService.CreateCategory(mapper);

			return Ok(result);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryViewModel updateCategoryViewModel)
		{
			if(id < 0) {  return BadRequest(); }

			var mapper = new UpdateCategoryModel
			{
				CategoryName = updateCategoryViewModel.CategoryName,
				TypeName = updateCategoryViewModel.TypeName
			};

			var result = _categoryService.UpdateCategory(id, mapper);

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			if (id < 0) { return BadRequest(); }

			var result = _categoryService.DeleteCategory(id);

			return Ok(result);
		}
    }
}