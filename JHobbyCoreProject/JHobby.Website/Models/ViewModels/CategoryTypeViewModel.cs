using JHobby.Repository.Models.Dto;

namespace JHobby.Website.Models.ViewModels
{
    public class CategoryTypeViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public IEnumerable<CategoryDetailViewModel> CategoryDetails { get; set; } = new List<CategoryDetailViewModel>();
    }
}