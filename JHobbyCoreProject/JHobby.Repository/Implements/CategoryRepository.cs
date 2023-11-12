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

        public IEnumerable<CategoryDto> GetAll()
        {
			var result = _jhobbyContext.Categories.Select(c => new CategoryDto
			{
				CategoryId = c.CategoryId,
				CategoryName = c.CategoryName,
				TypeName = c.TypeName,
			}).ToList();

			return result;
        }

        public CategoryDto GetById(int id)
        {
			var result = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);

			if (result == null) { return null; }

			return new CategoryDto
			{
				CategoryId = result.CategoryId,
				CategoryName = result.CategoryName, 
				TypeName = result.TypeName
			};
        }

        public bool UpdateCategory(int id, CategoryDto categoryDto)
        {
            var result = _jhobbyContext.Categories.Find(id);

			if(result != null)
			{
				result.CategoryName = categoryDto.CategoryName;
                result.TypeName = categoryDto.TypeName;

				_jhobbyContext.SaveChanges();

				return true;
			}

			return false;
        }
    }
}