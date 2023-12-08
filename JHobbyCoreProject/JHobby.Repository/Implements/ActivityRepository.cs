using AutoMapper;
using AutoMapper.Execution;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    /// <summary>
    /// 活動頁面查詢
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ActivityPageDto GetActivityPageById(int id)
    {
        var queryResult = _dbContext.Activities
            .Include(a => a.ActivityImages)
            .Where(a => a.ActivityId == id)
            .Select(a => new ActivityPageDto
            {
                ActivityId = a.ActivityId,
                MemberId = a.MemberId,
                ActivityLocation = a.ActivityLocation,
                CategoryId = a.CategoryId,
                CategoryTypeId = a.CategoryTypeId,
                ActivityName = a.ActivityName,
                StartTime = a.StartTime,
                JoinDeadLine = a.JoinDeadLine,
                ActivityNotes = a.ActivityNotes,
                ActivityImages = a.ActivityImages.Select(ai => new ActivityImageDto
                {
                    ActivityImageId = ai.ActivityImageId,
                    AiActivity = ai.ActivityImageId,
                    ImageName = ai.ImageName,
                    IsCover = ai.IsCover,
                    UploadTime = ai.UploadTime,
                }).ToList()
            }).FirstOrDefault();

        return queryResult;
    }

    /// <summary>
    /// 會員留言板查詢
    /// </summary>
    /// <returns></returns>
    public IEnumerable<MemberMsgDto> GetMsgList(int id)
    {
        var result = _dbContext.Members.Join(_dbContext.MsgBoards, m => m.MemberId, mb => mb.MemberId, (m, mb) => new MemberMsgDto
        {
            MemberId=mb.MemberId,
            ActivityId = mb.ActivityId,
            HeadShot = m.HeadShot,
            MessageTime = mb.MessageTime,
            MessageText = mb.MessageText,
            NickName = m.NickName
        }).Where(f => f.ActivityId == id).ToList();

        return result;
    }
    /// <summary>
    /// 會員留言板新增
    /// </summary>
    /// <param name="id"></param>
    /// <param name="memberInsertMsgDto"></param>
    /// <returns></returns>
    public bool InsertMsg(MemberInsertMsgDto memberInsertMsgDto)
    {
        var mapper = new MsgBoard
        {
            MemberId = memberInsertMsgDto.MemberId,
            ActivityId = memberInsertMsgDto.ActivityId,
            MessageTime = memberInsertMsgDto.MessageTime,
            MessageText = memberInsertMsgDto.MessageText,
        };

        _dbContext.MsgBoards.Add(mapper);
        _dbContext.SaveChanges();

        return true;
    }

    /// <summary>
    /// 查詢會員活動申請者是否已參團或本身是開團者
    /// </summary>
    /// <returns></returns>
    public bool GetStatusById(int memberId, int activityId)
    {
        if (_dbContext.Activities.Any(a => a.MemberId == memberId && a.ActivityId == activityId))
        {
            return true;
        }
        if (_dbContext.ActivityUsers.Any(a => a.MemberId == memberId && a.ActivityId == activityId))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 活動申請
    /// </summary>
    /// <returns></returns>
    public bool InsertActivityUser(ActivityUserInsertDto activityUserInsert)
    {
        if (_dbContext.ActivityUsers.Any(a=>a.ActivityId==activityUserInsert.ActivityId && a.MemberId==activityUserInsert.MemberId))
        {
            return false;
        }
        try
        {
            var mapper = new ActivityUser
            {
                MemberId = activityUserInsert.MemberId,
                ActivityId = activityUserInsert.ActivityId,
                ReviewStatus = activityUserInsert.ReviewStatus,
                ReviewTime = activityUserInsert.ReviewTime,
            };
            _dbContext.ActivityUsers.Add(mapper);
            _dbContext.SaveChanges();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}




















