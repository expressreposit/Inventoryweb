using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.PaymentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.PamentTypes
{
    public class PaymentTypeRepo : IPaymentTypeRepo
    {
        private ApplicationDbContext _context;

        public PaymentTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreatePaymentTypeViewModel vm)
        {
            var model = new CreatePaymentTypeViewModel().Convert(vm);
            _context.PaymentTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.PaymentTypes.Where(x => x.PaymentTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.PaymentTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public PagedResult<PaymentTypeViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<PaymentTypeViewModel> vmList = new List<PaymentTypeViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.PaymentTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.PaymentTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<PaymentTypeViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }
        private List<PaymentTypeViewModel> ConvertModelToViewModelList(List<PaymentType> modelList)
        {
            return modelList.Select(x => new PaymentTypeViewModel(x)).ToList();
        }
        public PaymentTypeViewModel GetById(int id)
        {
            var model = _context.PaymentTypes.Where(x => x.PaymentTypeId == id).FirstOrDefault();
            var vm = new PaymentTypeViewModel(model);
            return vm;
        }

        public void Update(PaymentTypeViewModel vm)
        {
            var model = _context.PaymentTypes.Where(x => x.PaymentTypeId ==vm.PaymentTypeId ).FirstOrDefault();
            if (model != null)
            {
                model.PaymentTypeName = vm.PaymentTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
