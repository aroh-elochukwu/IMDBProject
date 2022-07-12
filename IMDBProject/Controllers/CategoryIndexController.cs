using IMDBProject.Models;
using IMDBProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMDBProject.Controllers
{
    public class CategoryIndexController : Controller
    {
        private IMDBContext _db { get; set; }

        public CategoryIndexController(IMDBContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            CategorySelectViewModel vm = new CategorySelectViewModel(_db.Categories.ToList());
            return View(vm);
        }

        public IActionResult CategoryDetails(int? categoryId)
        {
            if (categoryId != null)
            {
                try
                {
                    Category category = _db.Categories.Include(c => c.Movies).First(c => c.Id == categoryId);
                    return View(category);
                }
                catch
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
