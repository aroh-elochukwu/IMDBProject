using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDBProject.Models.ViewModels
{
    public class CategorySelectViewModel
    {
        public List<SelectListItem> CategorySelect { get; set; }

        public CategorySelectViewModel(List<Category> categories)
        {
            CategorySelect = new List<SelectListItem>();
            categories.ForEach(c =>
            {
                CategorySelect.Add(new SelectListItem(c.Name, c.Id.ToString()));
            });
        }
    }
}
