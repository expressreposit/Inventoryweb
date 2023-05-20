using Inventory.Repository.BillTypeService;
using Inventory.Repository.SalesTypeService;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Sales;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class SalesTypesController : Controller
    {
        private ISalesTypeService _salesTypeRepo;

        public SalesTypesController(ISalesTypeService salesTypeRepo)
        {
            _salesTypeRepo = salesTypeRepo;
        }
        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var salesTypes = _salesTypeRepo.GetAll(pageNumber, pageSize);
            return View(salesTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSalesTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _salesTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _salesTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(SalesTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _salesTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _salesTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
