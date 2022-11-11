using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Models.Motorbike;

namespace MyFavoriteMotorbike.Controllers
{
    [Authorize]
    public class MotorbikeController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = new MotorbikesViewModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new MotorbikesViewModel();

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new MotorbikeDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(MotorbikeModel model)
        {
            int id = 1;

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var model = new MotorbikeModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MotorbikeModel model)
        {
            return RedirectToAction(nameof(Details), new { id });
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Vacate(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
