using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.SalesTypeService
{
    public class SalesTypeService : ISalesTypeService
    {
        private ApplicationDbContext _context;

        public SalesTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateSalesTypeViewModel vm)
        {
            var model = new CreateSalesTypeViewModel().Convert(vm);
            _context.SalesTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.SalesTypes.Where(x => x.SalesTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.SalesTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public PagedResult<SalesTypeListViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<SalesTypeListViewModel> vmList = new List<SalesTypeListViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.SalesTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.BillTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<SalesTypeListViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        public SalesTypeViewModel GetById(int id)
        {
            var model = _context.SalesTypes.Where(x => x.SalesTypeId == id).FirstOrDefault();
            var vm = new SalesTypeViewModel(model);
            return vm;
        }

        public void Update(SalesTypeViewModel vm)
        {
            var model = _context.SalesTypes.Where(x => x.SalesTypeId == vm.SalesTypeId).FirstOrDefault();
            if (model != null)
            {
                model.SalesTypeName = vm.SalesTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
        private List<SalesTypeListViewModel> ConvertModelToViewModelList(List<SalesType> modelList)
        {
            return modelList.Select(x => new SalesTypeListViewModel(x)).ToList();
        }

        
    
    
    
    }
}
