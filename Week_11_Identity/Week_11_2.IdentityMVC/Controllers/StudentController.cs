using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Week_11_2.IdentityMVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
