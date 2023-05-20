using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductService
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private ApplicationDbContext _context;

        public ProductTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateProductTypeViewModel vm)
        {
            var model = new CreateProductTypeViewModel().Convert(vm);
            _context.ProductTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.ProductTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public PagedResult<ProductTypeViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<ProductTypeViewModel> vmList = new List<ProductTypeViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.ProductTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.ProductTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<ProductTypeViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }
        private List<ProductTypeViewModel> ConvertModelToViewModelList(List<ProductType> modelList)
        {
            return modelList.Select(x => new ProductTypeViewModel(x)).ToList();
        }
        public ProductTypeViewModel GetById(int id)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            var vm = new ProductTypeViewModel(model);
            return vm;
        }

        public void Update(ProductTypeViewModel vm)
        {
            var model = _context.ProductTypes.Where(x => x.ProductTypeId == vm.ProductTypeId).FirstOrDefault();
            if (model != null)
            {
                model.ProductTypeName = vm.ProductTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
