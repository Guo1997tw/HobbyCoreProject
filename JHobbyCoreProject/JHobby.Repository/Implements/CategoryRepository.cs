using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Repository.Implements;

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
        return _mapper.Map<IEnumerable<CategoryDto>>(_jhobbyContext.Categories.AsNoTracking());
    }

    public CategoryDto GetById(int id)
    {
        return _mapper.Map<CategoryDto>(_jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id));
    }

    public bool Insert(CategoryCreateDto dto)
    {
        try
        {
            _jhobbyContext.Categories.Add(_mapper.Map<Category>(dto));
            _jhobbyContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(int id, CategoryUpdateDto dto)
    {
        try
        {
            var category = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null) return false;
            _mapper.Map(dto, category);
            _jhobbyContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var category = _jhobbyContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null) return false;
            _jhobbyContext.Categories.Remove(category);
            _jhobbyContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// 取得類型配細項
    /// </summary>
    /// <returns></returns>
    public IQueryable<CategoryTypeDto> GetCategoryIncludeType()
    {
        return _jhobbyContext.Categories.Include(c => c.CategoryDetails).Select(cd => new CategoryTypeDto
        {
            CategoryId = cd.CategoryId,
            CategoryName = cd.CategoryName,
            CategoryDetails = cd.CategoryDetails.Select(x => new CategoryDetailDto
            {
                CategoryTypeId = x.CategoryTypeId,
                CategoryId = x.CategoryId,
                TypeName = x.TypeName
            }).ToList()
        });
    }
}