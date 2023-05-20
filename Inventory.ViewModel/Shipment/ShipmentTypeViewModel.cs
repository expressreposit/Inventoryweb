using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Shipment
{
    public class ShipmentTypeViewModel
    {
        public int Id { get; set; }
       
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }
        public ShipmentTypeViewModel(ShipmentType model)
        {
            Id = model.Id;
            ShipmentTypeName = model.ShipmentTypeName;
            Description = model.Description;

        }

    }
}
