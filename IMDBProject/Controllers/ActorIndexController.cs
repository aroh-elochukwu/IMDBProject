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

        public IActionResult ActorCategory()
        {
            ActorCategorySelectViewModel vm = new ActorCategorySelectViewModel(_db.Categories.ToList());
            return View(vm);
        }

        public IActionResult CategoryDetail(int? categoryId)
        {
            
                try
                {
                    Category category = _db.Categories.Include(c => c.Movies).ThenInclude(m => m.Roles).ThenInclude(r => r.Actor).First(c => c.Id == categoryId);

                    return View(category);
                }catch
                {
                    return RedirectToAction("Error", "Home");
                }
            
        } 

        public IActionResult ActorDetails(int? actorId)
        {
            if (actorId != null)
            {
                try
                {
                    Actor actor = _db.Actors.Include(a => a.Roles).ThenInclude(r => r.Movie).First(a => a.Id == actorId);
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
