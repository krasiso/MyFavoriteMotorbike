using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Models;
using System.Diagnostics;

namespace MyFavoriteMotorbike.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMotorbikeService motorbikeService;

        public HomeController(IMotorbikeService _motorbikeService)
        {
            this.motorbikeService = _motorbikeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await motorbikeService.LastTwoRentedMotorbikes();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}