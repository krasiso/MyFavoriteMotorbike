using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Areas.Admin.Models;
using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Extensions;

namespace MyFavoriteMotorbike.Areas.Admin.Controllers
{
    public class MotorbikeAreaController : BaseController
    {
        private readonly IMotorbikeService motorbikeService;

        private readonly IGoldenClientService goldenClientService;

        public MotorbikeAreaController(
            IMotorbikeService _motorbikeService, 
            IGoldenClientService _goldenClientService)
        {
            motorbikeService = _motorbikeService;
            goldenClientService = _goldenClientService;
        }

        public async Task<IActionResult> Mine()
        {
            var myMotorbikes = new MyMotorbikesViewModel();
            var adminId = User.Id();

            myMotorbikes.RentedMotorbikes = await motorbikeService.AllMotorbikesByUserId(adminId);

            var goldenClientId = await goldenClientService.GetGoldenClientId(adminId);

            myMotorbikes.AddedMotorbikes = await motorbikeService.AllMotorbikesByGoldenClientId(goldenClientId);

            return View(myMotorbikes);
        }
    }
}
