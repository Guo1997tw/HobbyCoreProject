using JHobby.Service.Interfaces;
using JHobby.Service.Models.Dto;
using System.Security.Cryptography;

namespace JHobby.Service.Implements
{
    public class CommonService : ICommonService
    {

        readonly string _key = "HobbyKey";
        readonly string _iv = "27120589";


        /// <summary>
        /// 轉換ActivityStatus
        /// </summary>
        /// <param name="ActivityStatus"></param>
        /// <returns></returns>
        public string ConvertActivityStatus(string status)
        {
            return status switch
            {
                "0" => "黑名單",
                "1" => "進行中",
                "2" => "已完成",
                "3" => "已取消",
                _ => "未知"
            };
        }

        /// <summary>
        /// 轉換ReviewStatus
        /// </summary>
        /// <param name="ReviewStatus"></param>
        /// <returns></returns>
        public string ConvertReviewStatus(string status)
        {
            return status switch
            {
                "0" => "未通過",
                "1" => "通過",
                "2" => "待審核",
                "3" => "取消參加",
                "4" => "取消揪團",
                _ => "未知"
            };
        }

        /// <summary>
        /// 計算剩餘人數
        /// </summary>
        /// <param name="MaxPeople"></param>
        /// <param name="CurrentPeople"></param>
        /// <returns></returns>
        public int CountSurplusQuota(int? max, int? current)
        {
            return max.GetValueOrDefault() - current.GetValueOrDefault();
        }

        /// <summary>
        /// 將Sql Sever內的時間轉成日期格式和時間格式
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public IEnumerable<TimeModelDto> ConvertTime(DateTime dateTime)
        {
            string dateConvert = dateTime.ToString("yyyy-MM-dd");
            string timeConvert = dateTime.ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);

            TimeModelDto timeModelDto = new TimeModelDto
            {
                DateConvert = dateConvert,
                TimeConvert = timeConvert,
            };

            yield return timeModelDto;
        }
        /// <summary>
        /// 取字串檢查
        /// </summary>
        /// <param name="shotCheck"></param>
        /// <returns></returns>
        public int ShotCheck(int len, string str)
        {
            if (len >= str.Length)
            {
                len = str.Length;
            }
            return len;
        }
        public string ConvertGender(string Gender)
        {
            switch (Gender)
            {
                case "0":
                    return "女";
                case "1":
                    return "男";
                case "2":
                    return "雙性";
                default:
                    return "無此編號";
            }
        }

        public string ConvertStatus(string status)
        {
            switch (status)
            {
                case "0":
                    return "快速會員";
                case "1":
                    return "一般會員";
                case "2":
                    return "黑名單";
                case "9":
                    return "管理員";
                default:
                    return "無此身分別代號";
            }
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="data">加密數據</param>
        /// <param name="key">8位字元的密鑰字元串</param>
        /// <param name="iv">8位字元的初始化向量字元串</param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_iv);

            DES cryptoProvider = DES.Create();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(text);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密數據</param>
        /// <param name="key">8位字元的密鑰字元串(需要和加密時相同)</param>
        /// <param name="iv">8位字元的初始化向量字元串(需要和加密時相同)</param>
        /// <returns></returns>

        public string Decrypt(string encryptText)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(encryptText);
            }
            catch
            {
                return null;
            }

            DES cryptoProvider = DES.Create();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Base 64 Url 轉碼
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string EncodeBase64Url(string input)
        {
            string output = input;

            output = output.Split('=')[0];
            output = output.Replace('+', '-');
            output = output.Replace('/', '_');

            return output;
        }
        /// <summary>
        /// Base 64 Url 解碼
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string DecodeBase64Url(string input)
        {
            var output = input;

            output = output.Replace('-', '+');
            output = output.Replace('_', '/');

            switch (output.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    output += "==";
                    break;
                case 3:
                    output += "=";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(input), "非法字串!");
            }
            return output;
        }

        public int checkCurrentPeople(int? number)
        {
            return number == null ? 0 : number.Value;
        }
    }
}
