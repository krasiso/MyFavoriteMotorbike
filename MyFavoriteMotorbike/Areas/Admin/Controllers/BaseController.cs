using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MyFavoriteMotorbike.Areas.Admin.Constants.AdminConstants;

namespace MyFavoriteMotorbike.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]

    public class BaseController : Controller
    {
    }
}
