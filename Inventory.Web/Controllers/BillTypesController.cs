using Inventory.Repository.BillTypeService;
using Inventory.ViewModel.Bill;
using Inventory.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class BillTypesController : Controller
    {
        private IBillTypeRepo _billTypeRepo;

        public BillTypesController(IBillTypeRepo billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }
        [HttpGet]
        //[TypeFilter(typeof(CultureFilter), Arguments = new object[] { "af-ZA" })]
        public IActionResult Index(int pageSize=10,int pageNumber=1)
        {
            var billTypes = _billTypeRepo.GetAll(pageNumber, pageSize);
            return View(billTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
       
        public IActionResult Create(CreateBillTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
               _billTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _billTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(BillTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _billTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _billTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
        


    }
}
