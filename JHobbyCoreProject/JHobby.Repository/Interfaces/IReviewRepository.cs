﻿using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
	public interface IReviewRepository
	{
		public IEnumerable<ReviewDto> GetAll();
        public IEnumerable<ReviewDto> GetById(int id);
        public bool UpdateReviewStatus(int ActivityId, int ApplicantId, ReviewStatusDto reviewStatusDto);

    }
}
