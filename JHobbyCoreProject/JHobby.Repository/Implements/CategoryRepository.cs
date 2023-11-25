using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryRepository(JhobbyContext jhobbyContext, IMapper mapper)
        {
            _jhobbyContext = jhobbyContext;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var queryResult = _jhobbyContext.Categories.ToList();

            var mappingResult = _mapper.Map<IEnumerable<CategoryDto>>(queryResult);

            return mappingResult;

            //var queryResult = _jhobbyContext.Categories.Select(c => new CategoryDto
            //{
            //    CategoryId = c.CategoryId,
            //    CategoryName = c.CategoryName
            //}).ToList();

            //return queryResult;
        }

        public CategoryDto? GetById(int id)
        {
            var queryResult = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            
            if (queryResult == null) return null;

            return _mapper.Map<CategoryDto>(queryResult);

            //return new CategoryDto
            //{
            //    CategoryId = queryResult.CategoryId,
            //    CategoryName = queryResult.CategoryName,
            //};
		}

        public bool Insert(CreateCategoryDto createCategoryDto)
        {
            //var mapper = new Category
            //{
            //    CategoryName = createCategoryDto.CategoryName
            //};

            var mappingResult = _mapper.Map<Category>(createCategoryDto);

			_jhobbyContext.Categories.Add(mappingResult);
            _jhobbyContext.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            var queryResult = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (queryResult != null)
            {
                queryResult.CategoryName = updateCategoryDto.CategoryName;

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