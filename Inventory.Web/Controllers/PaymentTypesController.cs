using Inventory.Repository.BillTypeService;
using Inventory.Repository.PamentTypes;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.PaymentType;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class PaymentTypesController : Controller
    {
        private IPaymentTypeRepo _paymentTypeRepo;

        public PaymentTypesController(IPaymentTypeRepo paymentTypeRepo)
        {
            _paymentTypeRepo = paymentTypeRepo;
        }
        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var paymentTypes = _paymentTypeRepo.GetAll(pageNumber, pageSize);
            return View(paymentTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePaymentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _paymentTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _paymentTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(PaymentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _paymentTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _paymentTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
