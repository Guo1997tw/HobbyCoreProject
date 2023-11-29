namespace JHobby.Service.Interfaces
{
    public interface ICommonService
    {
        public string ConvertActivityStatus(string status);

        public string ConvertReviewStatus(string status);
        public int ShotCheck(int len, string str);
    }
}