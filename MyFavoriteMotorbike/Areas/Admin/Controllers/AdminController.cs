using Microsoft.AspNetCore.Mvc;

namespace MyFavoriteMotorbike.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
