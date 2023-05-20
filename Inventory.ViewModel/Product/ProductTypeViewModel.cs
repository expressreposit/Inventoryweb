using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Product
{
    public class ProductTypeViewModel
    {
        public int ProductTypeId { get; set; }
    
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
        public ProductTypeViewModel(ProductType model)
        {
            ProductTypeId = model.ProductTypeId;
            ProductTypeName = model.ProductTypeName;
            Description = model.Description;


        }

    }
}
