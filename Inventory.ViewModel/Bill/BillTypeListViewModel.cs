using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Bill
{
    public class BillTypeListViewModel
    {
        public int BillTypeId { get; set; }
        [Required]
        public string BillTypeName { get; set; }
        public string Description { get; set; }
        public BillTypeListViewModel()
        {

        }
        public BillTypeListViewModel(BillType model)
        {
            BillTypeId = model.BillTypeId;
            BillTypeName =model. BillTypeName;
            Description =model. Description;

        }

    }
}
