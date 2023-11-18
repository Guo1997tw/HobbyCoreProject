using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IndexApiController : ControllerBase
    {

		private readonly IIndexService _IndexService;

		public IndexApiController(IIndexService IndexService)
		{
			_IndexService = IndexService;
		}

		// GET: api/<IndexApiController>
		[HttpGet]
		public IEnumerable<QueryMemberGenderViewModel> GetGenderList()
		{
			var services = _IndexService.GetGenderResult();
			var viewModel = services.Select(s => new QueryMemberGenderViewModel
			{
				Totle = s.Totle,
				Man = s.Man,
				Woman = s.Woman
			});
			return viewModel;
		}


	}
}
