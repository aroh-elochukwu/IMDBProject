using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDBProject.Models.ViewModels
{
    public class ActorSelectViewModel
    {
        public List<SelectListItem> ActorSelect { get; set; }

        public ActorSelectViewModel(List<Actor> actors)
        {
            ActorSelect = new List<SelectListItem>();
            actors.ForEach(a =>
            {
                ActorSelect.Add(new SelectListItem(a.Name, a.Id.ToString()));
            });
        }
    }
}
