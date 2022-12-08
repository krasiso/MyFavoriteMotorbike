using Microsoft.AspNetCore.Mvc;
using MyFavoriteMotorbike.Core.Contracts.Admin;

namespace MyFavoriteMotorbike.Areas.Admin.Controllers
{
    public class UserAreaController : BaseController
    {
        private readonly IUserGoldenClientService userGoldenClientService;

        public UserAreaController(IUserGoldenClientService _userGoldenClientService)
        {
            userGoldenClientService = _userGoldenClientService;
        }

        public async Task<IActionResult> All()
        {
            var model = await userGoldenClientService.All();

            return View(model);
        }
    }
}
