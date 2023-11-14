using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
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

        public bool CreateCategory(CreateCategoryModel createCategoryModel)
        {
            var mapper = new CreateCategoryDto
            {
                CategoryName = createCategoryModel.CategoryName,
                TypeName = createCategoryModel.TypeName,
            };

            _categoryRepository.Insert(mapper);

            return true;
        }

        public bool UpdateCategory(int id, UpdateCategoryModel updateCategoryModel)
        {
            var queryResult = _categoryRepository.GetById(id);

            if (queryResult == null)
            {
                return false;
            }

            var dto = new UpdateCategoryDto
            {
                CategoryName = updateCategoryModel.CategoryName,
                TypeName = updateCategoryModel.TypeName,

            };

            _categoryRepository.Update(id, dto);

            return true;
        }
    }
}