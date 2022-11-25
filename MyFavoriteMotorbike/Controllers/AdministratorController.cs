//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MyFavoriteMotorbike.Core.Constants;
//using MyFavoriteMotorbike.Core.Contracts;
//using MyFavoriteMotorbike.Core.Models.Administrator;
//using MyFavoriteMotorbike.Extensions;

//namespace MyFavoriteMotorbike.Controllers
//{
//    [Authorize]
//    public class AdministratorController : Controller
//    {
//        private readonly IAdministratorService administratorService;

//        public AdministratorController(IAdministratorService _administratorService)
//        {
//            administratorService = _administratorService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Become()
//        {
//            if (await administratorService.ExistsById(User.Id()))
//            {
//                TempData[MessageConstant.ErrorMessage] = "You are already an Аdministrator!";

//                return RedirectToAction("Index", "Home");
//            }

//            var model = new BecomeAdministratorModel();

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Become(BecomeAdministratorModel model)
//        {
//            var userId = User.Id();

//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            if (await administratorService.ExistsById(userId))
//            {
//                TempData[MessageConstant.ErrorMessage] = "You are already an Аdministrator!";

//                return RedirectToAction("Index", "Home");
//            }

//            if (await administratorService.UserWithPhoneNumberExists(model.PhoneNumber))
//            {
//                TempData[MessageConstant.ErrorMessage] = "The phone number already exists!";

//                return RedirectToAction("Index", "Home");
//            }

//            if (await administratorService.UserHasRents(userId))
//            {
//                TempData[MessageConstant.ErrorMessage] = "You must have at least 10 bike rentals to become an admin!";
//            }

//            return RedirectToAction("All", "Motorbike");
//        }
//    }
//}
