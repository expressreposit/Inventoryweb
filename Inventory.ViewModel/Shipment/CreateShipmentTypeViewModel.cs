using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Shipment
{
    public class CreateShipmentTypeViewModel
    {
      
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
        public ShipmentType Convert(CreateShipmentTypeViewModel vm)
        {
            return new ShipmentType
            {
              
                ShipmentTypeName = vm.ShipmentTypeName,
                Description = vm.Description
               
            };
            
        }
    }
}
