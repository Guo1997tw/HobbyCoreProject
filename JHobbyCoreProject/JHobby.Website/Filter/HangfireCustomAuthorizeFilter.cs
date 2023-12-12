using Hangfire.Dashboard;
using System.Diagnostics.CodeAnalysis;

namespace JHobby.Website.Filter
{
    public class HangfireCustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}