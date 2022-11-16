using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Models.Administrator;

namespace MyFavoriteMotorbike.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAdministratorModel model)
        {
            return RedirectToAction("All", "Administrator");
        }
    }
}
