using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JHobby.Website.Controllers.Api
{
	[Route("api/[controller]/[action]")]
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

		[HttpPut("id")]
		public ActionResult UpdateCategorys(int id, [FromBody] CategoryViewModel categoryViewModel)
		{
			if (categoryViewModel == null) { return BadRequest(); }

			var servicesDto = _categoryService.GetDetail(id);

			if (servicesDto == null) { return NotFound(); }

			servicesDto.CategoryName = categoryViewModel.CategoryName;
            servicesDto.TypeName = categoryViewModel.TypeName;

			_categoryService.ReviseCategory(id, servicesDto);

			return Ok("已更改成功");
        }
    }
}