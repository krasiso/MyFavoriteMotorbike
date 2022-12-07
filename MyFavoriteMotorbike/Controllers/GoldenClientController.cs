using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Constants;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Core.Models.GoldenClient;
using MyFavoriteMotorbike.Extensions;

namespace MyFavoriteMotorbike.Controllers
{
    [Authorize]
    public class GoldenClientController : Controller
    {
        private readonly IGoldenClientService goldenClientService;

        public GoldenClientController(IGoldenClientService _goldenClientService)
        {
            goldenClientService = _goldenClientService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await goldenClientService.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a Golden Client!";

                return RedirectToAction("Index", "Home");
            }

            var model = new BecomeGoldenClientModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeGoldenClientModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await goldenClientService.ExistsById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a Golden Client!";

                return RedirectToAction("Index", "Home");
            }

            if (await goldenClientService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "The phone number already exists!";

                return RedirectToAction("Index", "Home");
            }

            if (await goldenClientService.UserHasRents(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You must have at least 10 bike rentals to become a Golden Client!";
            }

            return RedirectToAction("All", "Motorbike");
        }
    }
}
