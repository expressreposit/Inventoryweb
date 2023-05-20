using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Vendor
{
    public class VendorTypeViewModel
    {
        public int VendorTypeId { get; set; }
       
        public string VendorTypeName { get; set; }
        public string Description { get; set; }
        public VendorTypeViewModel()
        {

        }
        public VendorTypeViewModel(VendorType model)
        {
            VendorTypeId = model.VendorTypeId;
            VendorTypeName = model.VendorTypeName;
            Description = model.Description;

        }
        public VendorType Convert(VendorTypeViewModel vm)
        {
            VendorType model = new VendorType();
            model.VendorTypeId = vm.VendorTypeId;
            model.VendorTypeName = vm.VendorTypeName;
            model.Description = vm.Description;
            return model;
        }

    }
}
