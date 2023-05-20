using Inventory.Repository.CustomerTypeService;
using Inventory.Repository.Shipment;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Shipment;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class ShipmentTypeController : Controller
    {
        private IShipmentType _shipmentTypeRepo;

        public ShipmentTypeController(IShipmentType shipmentTypeRepo)
        {
            _shipmentTypeRepo = shipmentTypeRepo;
        }

        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var shipmentTypes = _shipmentTypeRepo.GetAll(pageSize, pageNumber);
            return View(shipmentTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateShipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _shipmentTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _shipmentTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(ShipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _shipmentTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _shipmentTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
