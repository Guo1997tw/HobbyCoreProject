using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;

        }

		public IEnumerable<CategoryModel> GetList()
		{
			var resultDto = _categoryRepository.GetAll();
			return _mapper.Map<IEnumerable<CategoryModel>>(resultDto);

			//var categoryModel = resultDto.Select(dto => new CategoryModel
			//{
			//	CategoryId = dto.CategoryId,
			//	CategoryName = dto.CategoryName
			//});

			//return categoryModel;
		}

		public CategoryModel GetDetail(int id)
		{
			var resultDto = _categoryRepository.GetById(id);

			var categoryModel = new CategoryModel
			{
				CategoryId = resultDto.CategoryId,
				CategoryName = resultDto.CategoryName
			};

			return categoryModel;
		}

		public bool CreateCategory(CreateCategoryModel createCategoryModel)
		{
			var mapper = new CategoryCreateDto
			{
				CategoryName = createCategoryModel.CategoryName
			};

			_categoryRepository.Insert(mapper);

			return true;
		}

		public bool UpdateCategory(int id, UpdateCategoryModel updateCategoryModel)
		{
			var queryResult = _categoryRepository.GetById(id);

			if (queryResult == null) return false;

			var dto = new CategoryUpdateDto
			{
				CategoryName = updateCategoryModel.CategoryName
			};

			_categoryRepository.Update(id, dto);

			return true;
		}

		public bool DeleteCategory(int id)
		{
			var queryResult = _categoryRepository.GetById(id);

			if (queryResult == null) return false;

			_categoryRepository.Delete(id);

			return true;
		}
	}
}