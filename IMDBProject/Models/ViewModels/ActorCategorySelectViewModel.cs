using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDBProject.Models.ViewModels
{
    public class ActorCategorySelectViewModel
    {
        public List<SelectListItem> ActorCategorySelect { get; set; }

        public ActorCategorySelectViewModel(List<Category> actorCategorySelect)
        {
            ActorCategorySelect = new List<SelectListItem>();

            actorCategorySelect.ForEach(a => { 
            ActorCategorySelect.Add(new SelectListItem(a.Name, a.Id.ToString()));
            });
        }   
    }
}
