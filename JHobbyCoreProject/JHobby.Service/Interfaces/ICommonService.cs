namespace JHobby.Service.Interfaces
{
    public interface ICommonService
    {
        public string ConvertActivityStatus(string status);

        public string ConvertReviewStatus(string status);

        public int CountSurplusQuota(int? max, int? current);
    }
}