using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Shipment
{
    public interface IShipmentType
    {
        PagedResult<ShipmentTypeViewModel> GetAll(int pageNumber, int pageSize);

        void Add(CreateShipmentTypeViewModel model);
        void Update(ShipmentTypeViewModel model);
        void Delete(int id);
        ShipmentTypeViewModel GetById(int id);

    }
}
