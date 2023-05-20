using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class BillController : Controller
    {
        public IActionResult Index()
        {
           
           return View();
        }
        
    }
}
