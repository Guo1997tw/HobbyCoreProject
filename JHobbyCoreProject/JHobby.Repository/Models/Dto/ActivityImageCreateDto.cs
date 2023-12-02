namespace JHobby.Repository.Models.Dto
{
    public class ActivityImageCreateDto
    {

        public string ImageName { get; set; } = null!;

        public bool IsCover { get; set; } = false;

        public DateTime UploadTime { get; set; } = DateTime.Now;

    }
}
