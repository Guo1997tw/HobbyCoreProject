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
            using (_jhobbyContext)
            {
                var queryResult = _jhobbyContext.Categories.Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    TypeName = c.TypeName,
                }).ToList();

                return queryResult;
            }
        }

        public CategoryDto? GetById(int id)
        {
            using (_jhobbyContext)
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
        }

        public bool Insert(CreateCategoryDto createCategoryDto)
        {
            using (_jhobbyContext)
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
        }

        public bool Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            var queryResult = _jhobbyContext.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (queryResult == null) { return false; };

            var mapper = new Category
            {
                CategoryName = updateCategoryDto.CategoryName,
                TypeName = updateCategoryDto.TypeName
            };

            queryResult.CategoryName = mapper.CategoryName;
            queryResult.TypeName = mapper.TypeName;

            _jhobbyContext.Categories.Update(queryResult);
            _jhobbyContext.SaveChanges();

            return true;
        }
    }
}