using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
	public interface ICategoryService
	{
		public IEnumerable<CategoryModel> GetList();

		public CategoryModel GetDetail(int id);

		public bool CreateCategory(CreateCategoryModel createCategoryModel);

		public bool UpdateCategory(int id, UpdateCategoryModel updateCategoryModel);
    }
}