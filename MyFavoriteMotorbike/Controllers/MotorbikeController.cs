using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Core.Models.Motorbike;
using MyFavoriteMotorbike.Extensions;
using static MyFavoriteMotorbike.Areas.Admin.Constants.AdminConstants;
using System.Security.Claims;

namespace MyFavoriteMotorbike.Controllers
{
    [Authorize]
    public class MotorbikeController : Controller
    {
        private readonly IMotorbikeService motorbikeService;

        private readonly IGoldenClientService goldenClientService;

        private readonly ILogger logger;

        public MotorbikeController(
            IMotorbikeService _motorbikeService,
            IGoldenClientService _goldenClientService,
            ILogger<MotorbikeController> _logger)
        {
            motorbikeService = _motorbikeService;
            goldenClientService = _goldenClientService;
            logger = _logger;
        }

        [HttpGet]
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
            query.Motorbikes = result.Motorbikes;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            //var userId = User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier)?.Value;
            //var model = await motorbikeService.GetMineAsync(userId);

            //return View("Mine", model);

            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Mine", "Motorbike", new { area = AreaName });
            }

            IEnumerable<MotorbikeServiceModel> myMotorbikes;
            var userId = User.Id();

            if (await goldenClientService.ExistsById(userId))
            {
                int goldenClientId = await goldenClientService.GetGoldenClientId(userId);
                myMotorbikes = await motorbikeService.AllMotorbikesByGoldenClientId(goldenClientId);
            }
            else
            {
                myMotorbikes = await motorbikeService.AllMotorbikesByUserId(userId);
            }

            return View(myMotorbikes);
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
        public async Task<IActionResult> Add()
        {
            if ((await goldenClientService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(GoldenClientController.Become), "GoldenClient");
            }

            var model = new MotorbikeModel()
            {
                MotorbikeCategories = await motorbikeService.AllCategories(),
                MotorbikeBrands = await motorbikeService.AllBrands()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MotorbikeModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MotorbikeCategories = await motorbikeService.AllCategories();

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.MotorbikeBrands = await motorbikeService.AllBrands();

                return View(model);
            }

            if (await goldenClientService.ExistsById(User.Id()))
            {
                return RedirectToAction(nameof(GoldenClientController.Become), "GoldenClient");
            }

            if (await motorbikeService.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists!");
            }

            if (await motorbikeService.BrandExists(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.BrandId), "Brand does not exists!");
            }

            int goldenClientId = await goldenClientService.GetGoldenClientId(User.Id());

            int id = await motorbikeService.Create(model, goldenClientId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await motorbikeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var motorbike = await motorbikeService.MotorbikeDetailsById(id);
            var category = await motorbikeService.GetMotorbikeCategoryId(id);
            var brand = await motorbikeService.AllBrandsNames();

            var model = new MotorbikeModel()
            {
                Id = id,
                Brand = motorbike.Brand,
                Variety = motorbike.Variety,
                CubicCentimeters = motorbike.CubicCentimeters,
                Description = motorbike.Description,
                PricePerDay = motorbike.PricePerDay,
                MotorbikeCategories = await motorbikeService.AllCategories(),
                MotorbikeBrands = await motorbikeService.AllBrands()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MotorbikeModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.MotorbikeCategories = await motorbikeService.AllCategories();

                return View(model);
            }

            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await motorbikeService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "This motorbike does not exist!");
                model.MotorbikeCategories = await motorbikeService.AllCategories();

                return View(model);
            }

            if ((await motorbikeService.HasGoldenClientWithId(model.Id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await motorbikeService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.MotorbikeCategories = await motorbikeService.AllCategories();

                return View(model);
            }

            await motorbikeService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await motorbikeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await motorbikeService.HasGoldenClientWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var motorbike = await motorbikeService.MotorbikeDetailsById(id);
            var model = new MotorbikeDetailsViewModel()
            {
                Brand = motorbike.Brand,
                Variety = motorbike.Variety,
                ImageUrl = motorbike.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, MotorbikeDetailsViewModel model)
        {
            if ((await motorbikeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await motorbikeService.HasGoldenClientWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await motorbikeService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if ((await motorbikeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRoleName) && await goldenClientService.ExistsById(User.Id()))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
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
