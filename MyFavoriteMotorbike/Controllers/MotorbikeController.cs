using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Core.Models.Motorbike;
using MyFavoriteMotorbike.Extensions;
using System.Security.Claims;

namespace MyFavoriteMotorbike.Controllers
{
    [Authorize]
    public class MotorbikeController : Controller
    {
        private readonly IMotorbikeService motorbikeService;

        //private readonly IAdministratorService administratorService;

        public MotorbikeController(IMotorbikeService _motorbikeService)//, IAdministratorService _administratorService)
        {
            motorbikeService = _motorbikeService;
            //administratorService = _administratorService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllMotorbikesQueryModel query)
        {
            var result = await motorbikeService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllMotorbikesQueryModel.MotorbikesPerPage);

            query.TotalMotorbikesCount = result.TotalMotorbikesCount;
            query.Categories = await motorbikeService.AllCategoriesNames();

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            //IEnumerable<MotorbikeServiceModel> myFavoriteMotorbikes;
            var userId = User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await motorbikeService.GetMineAsync(userId);

            return View("Mine", model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await motorbikeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await motorbikeService.MotorbikeDetailsById(id);

            return View(model);
        }

        [HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    if ((await administratorService.ExistsById(User.Id())) == false)
        //    {
        //        return RedirectToAction(nameof(AdministratorController.Become), "Administrator");
        //    }

        //    var model = new MotorbikeModel()
        //    {
        //        MotorbikeCategories = await motorbikeService.AllCategories()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(MotorbikeModel model)
        //{
        //    //if (await administratorService.ExistsById(User.Id()))
        //    //{
        //    //    return RedirectToAction(nameof(AdministratorController.Become), "Administrator");
        //    //}

        //    if (await motorbikeService.CategoryExists(model.CategoryId) == false)
        //    {
        //        ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists!");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        model.MotorbikeCategories = await motorbikeService.AllCategories();

        //        return View(model);
        //    }

        //    //int administratorId = await administratorService.GetAdministratorId(User.Id());

        //    int id = await motorbikeService.Create(model)//, administratorId);

        //    return RedirectToAction(nameof(Details), new { id });
        //}

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
        
        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return RedirectToAction(nameof(All));
        //}

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if ((await motorbikeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (await motorbikeService.IsRented(id))
            {
                return RedirectToAction(nameof(All));
            }

            await motorbikeService.Rent(id, User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Vacate(int id)
        {
            if ((await motorbikeService.Exists(id)) == false || (await motorbikeService.IsRented(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            if ((await motorbikeService.IsRentedByUserWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDnied", new { area = "Identity" });
            }

            await motorbikeService.Vacate(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
