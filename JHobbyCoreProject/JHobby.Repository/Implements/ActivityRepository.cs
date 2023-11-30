using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;

namespace JHobby.Repository.Implements;

public class ActivityRepository : IActivityRepository
{
    private readonly JhobbyContext _dbContext;
    private readonly IMapper _mapper;

    public ActivityRepository(JhobbyContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public bool Insert(ActivityCreateDto dto)
    {
        try
        {
            _dbContext.Activities.Add(_mapper.Map<Activity>(dto));
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}