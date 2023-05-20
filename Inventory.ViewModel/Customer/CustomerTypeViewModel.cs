using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Customer
{
    public class CustomerTypeViewModel
    {
        public int CustomerTypeId { get; set; }
       
        public string CustomerTypeName { get; set; }
        public string Description { get; set; }
        public CustomerTypeViewModel(CustomerType model)
        {
            CustomerTypeId = model.CustomerTypeId;
            CustomerTypeName = model.CustomerTypeName;
            Description = model.Description;

        }

    }
}
