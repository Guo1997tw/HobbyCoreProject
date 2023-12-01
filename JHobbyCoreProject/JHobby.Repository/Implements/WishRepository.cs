using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Repository.Implements;

public class WishRepository : IWishRepository
{
    private readonly JhobbyContext _dbContext;
    private readonly IMapper _mapper;

    public WishRepository(JhobbyContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<WishDto> GetById(int id)
    {
        return _mapper.Map<IEnumerable<WishDto>>(_dbContext.Wishes.AsNoTracking().Where(w => w.MemberId == id));
    }

    public bool Create(WishCreateDto dto)
    {
        try
        {
            _dbContext.Wishes.Add(_mapper.Map<Wish>(dto));
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete(int memberId, int activityId)
    {
        try
        {
            var wish = _dbContext.Wishes.FirstOrDefault(
                w => w.MemberId == memberId && w.ActivityId == activityId);
            if (wish == null) return false;
            _dbContext.Wishes.Remove(wish);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception )
        {
            return false;
        }
    }
}