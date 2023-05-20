using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Sales
{
    public class CreateSalesTypeViewModel
    {
       
        public string SalesTypeName { get; set; }
        public string Description { get; set; }
        public SalesType Convert(CreateSalesTypeViewModel model)
        {
            var salesType = new SalesType();
            salesType.SalesTypeName = model.SalesTypeName;
            salesType.Description = model.Description;
            return salesType;
        }

    }
}
