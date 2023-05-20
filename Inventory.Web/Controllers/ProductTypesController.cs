using Inventory.Repository.BillTypeService;
using Inventory.Repository.ProductService;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class ProductTypesController : Controller
    {
        private IProductTypeRepo _productTypeRepo;

        public ProductTypesController(IProductTypeRepo productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }
        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var productTypes = _productTypeRepo.GetAll(pageNumber, pageSize);
            return View(productTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
