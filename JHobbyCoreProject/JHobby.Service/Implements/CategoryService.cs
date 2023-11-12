using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

        public IEnumerable<CategoryModel> GetList()
        {
			var resultDto = _categoryRepository.GetAll().ToList();

			var categoryModel = resultDto.Select(dto => new CategoryModel
			{
				CategoryId = dto.CategoryId,
				CategoryName = dto.CategoryName,
				TypeName = dto.TypeName,
			});

			return categoryModel;
        }

        public CategoryModel GetDetail(int id)
        {
            var resultDto = _categoryRepository.GetById(id);

			var categoryModel = new CategoryModel
			{
				CategoryId = resultDto.CategoryId,
				CategoryName = resultDto.CategoryName,
				TypeName = resultDto.TypeName,
			};

            return categoryModel;
        }

        public bool ReviseCategory(int id, CategoryModel categoryModel)
        {
			var resultDto = _categoryRepository.GetById(id);

			if(resultDto == null)
			{
                return false;
            }

            resultDto.CategoryName = categoryModel.CategoryName;
            resultDto.TypeName = categoryModel.TypeName;

			_categoryRepository.UpdateCategory(id, resultDto);

			return true;
        }
    }
}