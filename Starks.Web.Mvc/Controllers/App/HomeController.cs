using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Starks.Web.Mvc.Controllers.App
{
    [Route("App/Home")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}