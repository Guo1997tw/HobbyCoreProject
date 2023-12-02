using JHobby.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            Claim userClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);
            
            if (userClaim != null && int.TryParse(userClaim.Value, out int id)) return id;
            
            throw new InvalidOperationException("找不到此會員ID!!");
        }
    }
}