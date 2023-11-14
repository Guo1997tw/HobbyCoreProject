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
            var queryResult = _jhobbyContext.Categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                TypeName = c.TypeName,
            }).ToList();

            return queryResult;
        }

        public CategoryDto? GetById(int id)
        {
            var queryResult = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (queryResult == null) return null;

            return new CategoryDto
            {
                CategoryId = queryResult.CategoryId,
                CategoryName = queryResult.CategoryName,
                TypeName = queryResult.TypeName
            };
        }

        public bool Insert(CreateCategoryDto createCategoryDto)
        {
            var mapper = new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                TypeName = createCategoryDto.TypeName
            };

            _jhobbyContext.Categories.Add(mapper);
            _jhobbyContext.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            var queryResult = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (queryResult != null)
            {
                queryResult.CategoryName = updateCategoryDto.CategoryName;
                queryResult.TypeName = updateCategoryDto.TypeName;

                _jhobbyContext.SaveChanges();

                return true;
            };

            return false;
        }

        public bool Delete(int id)
        {
            var queryResult = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);

            if(queryResult == null) { return false; }

            _jhobbyContext.Categories.Remove(queryResult);
            _jhobbyContext.SaveChanges();

            return true;
        }
    }
}