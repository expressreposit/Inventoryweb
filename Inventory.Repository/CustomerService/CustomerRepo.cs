using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerService
{
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateCustomerViewModel vm)
        {
            var model = new CreateCustomerViewModel().Convert(vm);
            _context.Customers.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var mdoel = _context.Customers.Find(id);
            if (mdoel != null)
            {
                _context.Customers.Remove(mdoel);
                _context.SaveChanges();
            }
        }

        public PagedResult<CustomerViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<CustomerViewModel> vmList = new List<CustomerViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
               
                var modelList =  (from c in _context.Customers
                                  join ct in _context.CustomerTypes
                                  on c.CustomerTypeId equals ct.CustomerTypeId
                                select c).Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = (from c in _context.Customers
                              select c).Count();
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<CustomerViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }
        private List<CustomerViewModel> ConvertModelToViewModelList(List<Inventory.Models.Customer> modelList)
        {
            return modelList.Select(x => new CustomerViewModel(x)).ToList();
        }

        public CustomerViewModel GetById(int id)
        {
            var model = _context.Customers.Include(x => x.CustomerType).Where(x=>x.CustomerId==id).FirstOrDefault();
            var vm = new CustomerViewModel(model);
            return vm;
        }

        public void Update(CustomerViewModel vm)
        {
            var model = _context.Customers.Where(x => x.CustomerId == vm.CustomerId).FirstOrDefault();
            if (model != null)
            {
                model.Address = vm.Address;
                model.CustomerName = vm.CustomerName;
                model.Email = vm.Email;
                model.Phone = vm.Phone;
                model.CustomerTypeId = vm.CustomerTypeId;
               model.City   = vm.City;
                model.ZioCode   = vm.ZioCode;
                model.Phone = vm.Phone;
                model.ContactPerson= vm.ContactPerson;


                
            }
            _context.SaveChanges();
        }
    }
}
