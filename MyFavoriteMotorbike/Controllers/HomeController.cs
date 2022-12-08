using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Models;
using System.Diagnostics;
using static MyFavoriteMotorbike.Areas.Admin.Constants.AdminConstants;

namespace MyFavoriteMotorbike.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMotorbikeService motorbikeService;

        public HomeController(IMotorbikeService _motorbikeService)
        {
            motorbikeService = _motorbikeService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var model = await motorbikeService.LastRentedMotorbikes();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}