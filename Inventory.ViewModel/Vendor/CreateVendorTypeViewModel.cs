using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Vendor
{
    public class CreateVendorTypeViewModel
    {
        public string VendorTypeName { get; set; }
        public string Description { get; set; }
        public CreateVendorTypeViewModel()
        {

        }
        public CreateVendorTypeViewModel(VendorType model)
        {
            VendorTypeName = model.VendorTypeName;
            Description = model.Description;

        }
        public VendorType Convert(CreateVendorTypeViewModel vm)
        {
            VendorType model = new VendorType();
            model.VendorTypeName = vm.VendorTypeName;
            model.Description = vm.Description;
            return model;

        }

    }
}
