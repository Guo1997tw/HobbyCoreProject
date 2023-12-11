namespace JHobby.Website.Models.ViewModels
{
    public class PageFilterViewModel<T>
    {
        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
