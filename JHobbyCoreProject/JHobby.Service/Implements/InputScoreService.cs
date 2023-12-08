using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class InputScoreService : IinputScoreService
    {
        private readonly IinputScoreRepository _iiputScoreRepository;

        public InputScoreService(IinputScoreRepository iinputScoreRepository) 
        {
            _iiputScoreRepository = iinputScoreRepository;
        }

        public bool NewInputScoreById(InputScoreModel inputScoreModel)
        {
            var inputScoreDto = new InputScoreDto
            {
                ActivityId = inputScoreModel.ActivityId,
                Fraction = inputScoreModel.Fraction,
                MemberId = inputScoreModel.MemberId,
                EvaluationTime = DateTime.UtcNow,
            };

            return _iiputScoreRepository.NewInputScoreById(inputScoreDto);
        }
    }
}
