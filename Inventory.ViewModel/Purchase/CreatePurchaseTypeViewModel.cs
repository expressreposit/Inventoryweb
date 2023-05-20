using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Purchase
{
    public class CreatePurchaseTypeViewModel
    {
      
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }

        public PurchaseType Convert(CreatePurchaseTypeViewModel vm)
        {
            var model = new PurchaseType();
            model.PurchaseTypeName = vm.PurchaseTypeName;
            model.Description = vm.Description;
            return model;
           
        }
    }
}
