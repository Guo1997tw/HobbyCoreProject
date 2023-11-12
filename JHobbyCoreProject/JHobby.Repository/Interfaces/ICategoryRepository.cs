using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
	public interface ICategoryRepository
	{
		public IEnumerable<CategoryDto> GetAll();

		public CategoryDto GetById(int id);

		public bool UpdateCategory(int id, CategoryDto categoryDto);
    }
}