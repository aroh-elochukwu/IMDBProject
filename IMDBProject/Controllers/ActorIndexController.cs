using IMDBProject.Models;
using IMDBProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMDBProject.Controllers
{
    public class ActorIndexController : Controller
    {
        
        private IMDBContext _db { get; set; }

        public ActorIndexController(IMDBContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            ActorSelectViewModel vm = new ActorSelectViewModel(_db.Actors.ToList());
            return View(vm);
        }

        public IActionResult ActorDetails(int? actorId)
        {
            if (actorId != null)
            {
                try
                {
                    Actor actor = _db.Actors.Include(a => a.Roles).First(a => a.Id == actorId);
                    return View(actor);
                } catch
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
