using Inventory.Repository.CustomerService;
using Inventory.Repository.CustomerTypeService;
using Inventory.ViewModel.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepo _customerRepo;
        private ICustomerTypeRepo _customerTypeRepo;

        public CustomerController(ICustomerRepo customerRepo, 
            ICustomerTypeRepo customerTypeRepo)
        {
            _customerRepo = customerRepo;
            _customerTypeRepo = customerTypeRepo;
        }

        //intialize

        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var customers = _customerRepo.GetAll(pageSize, pageNumber);
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.customerTypes = new SelectList(_customerTypeRepo.GetALLWithoutPaging(), "CustomerTypeId", "CustomerTypeName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _customerRepo.GetById(id);
            ViewBag.customerTypes = new SelectList(_customerTypeRepo.GetALLWithoutPaging(), "CustomerTypeId", "CustomerTypeName",model.CustomerTypeId);
            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _customerRepo.Delete(id);
            return RedirectToAction("Index");
        }




    }
}
