using JHobby.Service.Models.Dto;

namespace JHobby.Service.Interfaces
{
    public interface ICommonService
    {
        public string ConvertActivityStatus(string status);

        public string ConvertReviewStatus(string status);

        public int CountSurplusQuota(int? max, int? current);

        public IEnumerable<TimeModelDto> ConvertTime(DateTime dateTime);
        public int ShotCheck(int len, string str);

        public string ConvertGender(string Gender);

        public string ConvertStatus(string status);

        public string Encrypt(string text);

        public string Decrypt(string encryptText);

        public string EncodeBase64Url(string input);

        public string DecodeBase64Url(string input);

        public int checkCurrentPeople(int? number);

    }
}