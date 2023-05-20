using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private ApplicationDbContext _context;

        public BillTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Add(CreateBillTypeViewModel model)
        {
            var billType = model.VMToModel();
            _context.BillTypes.Add(billType);
            _context.SaveChanges();
        }

        public void Update(BillTypeViewModel vm)
        {

            var model =  _context.BillTypes.Where(x => x.BillTypeId == vm.BillTypeId).FirstOrDefault();
            if (model!=null)
            {
                model.BillTypeName = vm.BillTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
           
        }

        public void Delete(int id)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.BillTypes.Remove(model);
            }
            _context.SaveChanges();
            
        }

        public BillTypeViewModel GetById(int id)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == id).FirstOrDefault();
            var vm = new BillTypeViewModel(model);
            return vm;
            
        }

        PagedResult<BillTypeListViewModel> IBillTypeRepo.GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<BillTypeListViewModel> vmList = new List<BillTypeListViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.BillTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.BillTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<BillTypeListViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }
        private List<BillTypeListViewModel> ConvertModelToViewModelList(List<BillType> modelList)
        {
            return modelList.Select(x => new BillTypeListViewModel(x)).ToList();
        }


    }
}
