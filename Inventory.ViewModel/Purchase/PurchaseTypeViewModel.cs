using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Purchase
{
    public class PurchaseTypeViewModel
    {
        public int PurchaseTypeId { get; set; }
       
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
        public PurchaseTypeViewModel(PurchaseType model)
        {
            PurchaseTypeId = model.PurchaseTypeId;
            PurchaseTypeName = model.PurchaseTypeName;
            Description = model.Description;

        }

    }
}
