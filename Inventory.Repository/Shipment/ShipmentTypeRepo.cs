using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.PaymentType;
using Inventory.ViewModel.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Shipment
{
    public class ShipmentTypeRepo : IShipmentType
    {
        private ApplicationDbContext _context;

        public ShipmentTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CreateShipmentTypeViewModel vm)
        {
            var model = new CreateShipmentTypeViewModel().Convert(vm);
            _context.ShipmentTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.ShipmentTypes.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                _context.ShipmentTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public PagedResult<ShipmentTypeViewModel> GetAll(int pageNumber, int pageSize)
        {
            int totalCount = 0;
            List<ShipmentTypeViewModel> vmList = new List<ShipmentTypeViewModel>();
            try
            {
                int ExcludeRecords = ((pageSize * pageNumber) - pageSize);
                var modelList = _context.ShipmentTypes
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _context.ShipmentTypes.ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception ex) { throw; }
            var result = new PagedResult<ShipmentTypeViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }
        private List<ShipmentTypeViewModel> ConvertModelToViewModelList(List<ShipmentType> modelList)
        {
            return modelList.Select(x => new ShipmentTypeViewModel(x)).ToList();
        }


        public ShipmentTypeViewModel GetById(int id)
        {
            var model = _context.ShipmentTypes.Where(x => x.Id == id).FirstOrDefault();
            var vm = new ShipmentTypeViewModel(model);
            return vm;
        }

        public void Update(ShipmentTypeViewModel vm)
        {

            var model = _context.ShipmentTypes.Where(x => x.Id == vm.Id).FirstOrDefault();
            if (model != null)
            {
                model.ShipmentTypeName = vm.ShipmentTypeName;
                model.Description = vm.Description;
            }
            _context.SaveChanges();
        }
    }
}
