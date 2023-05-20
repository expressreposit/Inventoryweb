using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.PaymentType;
using Inventory.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Purchase
{
    public class PurchaseTypeRepo : IPurchaseTypeRepo
    {
        private ApplicationDbContext _context;

        public PurchaseTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreatePurchaseTypeViewModel vm)
        {
            var model = new CreatePurchaseTypeViewModel().Convert(vm);
            _context.PurchaseTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.PurchaseTypes.Where(x => x.PurchaseTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.PurchaseTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public PagedResult<PurchaseTypeViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<PurchaseTypeViewModel> vmList = new List<PurchaseTypeViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.PurchaseTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.PurchaseTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<PurchaseTypeViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        private List<PurchaseTypeViewModel> ConvertModelToViewModelList(List<PurchaseType> modelList)
        {
            return modelList.Select(x => new PurchaseTypeViewModel(x)).ToList();
        }
        public PurchaseTypeViewModel GetById(int id)
        {
            var model = _context.PurchaseTypes.Where(x => x.PurchaseTypeId == id).FirstOrDefault();
            var vm = new PurchaseTypeViewModel(model);
            return vm;
        }

        public void Update(PurchaseTypeViewModel vm)
        {
            var model = _context.PurchaseTypes.Where(x => x.PurchaseTypeId == vm.PurchaseTypeId).FirstOrDefault();
            if (model != null)
            {
                model.PurchaseTypeName = vm.PurchaseTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
