using Microsoft.AspNetCore.Mvc;
using BinaryNetCoreApp.Services;

namespace BinaryNetCoreApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        ISimpleModelService simpleModelService;
        public HomeController(ISimpleModelService isms)
        {
            simpleModelService = isms;
        }
       public IActionResult Index()
       {
            return View(simpleModelService.GetAll());
       }
    }
}
