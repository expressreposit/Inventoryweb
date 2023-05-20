using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Sales
{
    public class SalesTypeViewModel
    {
        public int SalesTypeId { get; set; }
       
        public string SalesTypeName { get; set; }
        public string Description { get; set; }
        public SalesTypeViewModel(SalesType model)
        {
            SalesTypeId = model.SalesTypeId;
            SalesTypeName = model.SalesTypeName;
            Description = model.Description;

        }

    }
}
