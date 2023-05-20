using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.VendorTypeService
{
    public class VendorTypeRepo : IVendorTypeRepo
    {
        private readonly ApplicationDbContext  _context;

        public VendorTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateVendorTypeViewModel vm)
        {
            var model = new CreateVendorTypeViewModel().Convert(vm);
            _context.VendorTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var mdoel = _context.VendorTypes.Find(id);
            if (mdoel != null)
            {
                _context.VendorTypes.Remove(mdoel);
                _context.SaveChanges();
            }
        }

        public PagedResult<VendorTypeViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<VendorTypeViewModel> vmList = new List<VendorTypeViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.VendorTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.VendorTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<VendorTypeViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        private List<VendorTypeViewModel> ConvertModelToViewModelList(List<VendorType> modelList)
        {
            return modelList.Select(x => new VendorTypeViewModel(x)).ToList();
        }

        public VendorTypeViewModel GetById(int id)
        {
            var model = _context.VendorTypes.Find(id);
            var vm = new VendorTypeViewModel(model);
            return vm;

        }

        public void Update(VendorTypeViewModel vm)
        {
            var model = _context.VendorTypes.Where(x => x.VendorTypeId == vm.VendorTypeId).FirstOrDefault();
            if (model != null)
            {
                model.Description = vm.Description;
                model.VendorTypeName = vm.VendorTypeName;
            }
            _context.SaveChanges();
        }
    }
}
