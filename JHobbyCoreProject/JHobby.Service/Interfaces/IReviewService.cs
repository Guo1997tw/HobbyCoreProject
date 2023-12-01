using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
	public interface IReviewService
	{
		public IEnumerable<ReviewModel> GetReviewList();
		public IEnumerable<ReviewModel> GetById(int id);
        public bool UpdateReviewStatus(int ActivityId, int ApplicantId, ReviewStatusModel reviewStatusModel);
    }
}
