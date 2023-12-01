using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Repository.Implements;

public class CategoryRepository : ICategoryRepository
{
    private readonly JhobbyContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryRepository(JhobbyContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<CategoryDto> GetAll()
    {
        return _mapper.Map<IEnumerable<CategoryDto>>(_dbContext.Categories.AsNoTracking());
    }

    public CategoryDto GetById(int id)
    {
        return _mapper.Map<CategoryDto>(_dbContext.Categories.FirstOrDefault(c => c.CategoryId == id));
    }

    public bool Insert(CategoryCreateDto dto)
    {
        try
        {
            _dbContext.Categories.Add(_mapper.Map<Category>(dto));
            _dbContext.SaveChanges();
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
            var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null) return false;
            _mapper.Map(dto, category);
            _dbContext.SaveChanges();
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
            var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null) return false;
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}