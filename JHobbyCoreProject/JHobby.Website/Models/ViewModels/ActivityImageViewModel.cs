namespace JHobby.Website.Models.ViewModels
{
    public class ActivityImageViewModel
    {
        public int ActivityImageId { get; set; }

        public int AiActivity { get; set; }

        public string ImageName { get; set; } = null!;

        public bool IsCover { get; set; }

        public DateTime UploadTime { get; set; }
    }
}