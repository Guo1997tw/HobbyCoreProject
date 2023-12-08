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

		public bool Insert(CategoryCreateDto dto);

        public bool Update(int id, CategoryUpdateDto dto);

		public bool Delete(int id);

		public IQueryable<CategoryTypeDto> GetCategoryIncludeType();
    }
}