using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
    public class InputScoreRepository : IinputScoreRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public InputScoreRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }

        public bool NewInputScoreById(InputScoreDto inputScoreDto)
        {
            var inputScore = new Score
            {
                ActivityId = inputScoreDto.ActivityId,
                MemberId = inputScoreDto.MemberId,
                Fraction = inputScoreDto.Fraction,
                EvaluationTime = inputScoreDto.EvaluationTime,
            };

                _jhobbyContext.Scores.Add(inputScore);
                _jhobbyContext.SaveChanges();
            
            return true;
        }
    }
}
