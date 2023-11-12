using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly JhobbyContext _jhobbyContext;

		public CategoryRepository(JhobbyContext jhobbyContext)
		{
			_jhobbyContext = jhobbyContext;
		}

		public IEnumerable<CategoryDto> GetCategoryList()
		{
			return _jhobbyContext.Categories.Select(c => new CategoryDto
			{
				CategoryName = c.CategoryName,
				TypeName = c.TypeName,
			}).ToList();
		}
	}
}