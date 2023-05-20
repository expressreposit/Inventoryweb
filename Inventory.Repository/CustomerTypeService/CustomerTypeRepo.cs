using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerTypeService
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private ApplicationDbContext _context;

        public CustomerTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateCustomerTypeViewModel vm)
        {
            var model = new CreateCustomerTypeViewModel().Convert(vm);
            _context.CustomerTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var mdoel =  _context.CustomerTypes.Find(id);
            if (mdoel != null) {
            _context.CustomerTypes.Remove(mdoel);
            _context.SaveChanges();
            }
        }

        public PagedResult<CustomerTypeListViewModel> GetAll(int pageSize,int pageNumber)
        {
            int totalCount = 0;
            List<CustomerTypeListViewModel> vmList = new List<CustomerTypeListViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.CustomerTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.CustomerTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<CustomerTypeListViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;

        }

        public IEnumerable<CustomerTypeListViewModel> GetALLWithoutPaging()
        {
           var modelList =  _context.CustomerTypes.ToList();
            var viewModelList = ConvertModelToViewModelList(modelList);
            return viewModelList;
        }

        public CustomerTypeViewModel GetById(int id)
        {
           var model  =  _context.CustomerTypes.Find(id);
            var vm = new CustomerTypeViewModel(model);
            return vm;

        }

        public PagedResult<CustomerTypeListViewModel> Search(string searching, int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<CustomerTypeListViewModel> vmList = new List<CustomerTypeListViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.CustomerTypes.Where(x=>x.CustomerTypeName.Contains(searching))
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.CustomerTypes.Where(x => x.CustomerTypeName.Contains(searching)).ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<CustomerTypeListViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }

        public void Update(CustomerTypeViewModel vm)
        {
            var model = _context.CustomerTypes.Where(x => x.CustomerTypeId == vm.CustomerTypeId).FirstOrDefault();
            if (model != null)
            {
                model.Description = vm.Description;
                model.CustomerTypeName = vm.CustomerTypeName;
            }
            _context.SaveChanges();
        }

        private List<CustomerTypeListViewModel> ConvertModelToViewModelList(List<CustomerType> modelList)
        {
            return modelList.Select(x => new CustomerTypeListViewModel(x)).ToList();
        }

    }
}
