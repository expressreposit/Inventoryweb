using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Customer
{
    public class CreateCustomerTypeViewModel
    {
        public string CustomerTypeName { get; set; }
        public string Description { get; set; }
        public CreateCustomerTypeViewModel()
        {

        }
        public CustomerType Convert(CreateCustomerTypeViewModel model)
        {
            return new CustomerType
            {
                CustomerTypeName = model.CustomerTypeName,
                Description = model.Description
            };
        }

    }
}
