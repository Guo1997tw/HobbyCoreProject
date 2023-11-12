using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
	}
}