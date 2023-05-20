using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Product
{
    public class CreateProductTypeViewModel
    {
        
        public string ProductTypeName { get; set; }
        public string Description { get; set; }

        public ProductType Convert(CreateProductTypeViewModel vm)
        {
            var productType = new ProductType();
            productType.ProductTypeName = vm.ProductTypeName;
            productType.Description = vm.Description;
            return productType;

           
        }
    }
}
