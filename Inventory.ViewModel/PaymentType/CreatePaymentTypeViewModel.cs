using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.PaymentType
{
    public class CreatePaymentTypeViewModel
    {
       
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }

        public Inventory.Models.PaymentType Convert(CreatePaymentTypeViewModel vm)
        {
            return new Inventory.Models.PaymentType
            {
                PaymentTypeName = vm.PaymentTypeName,
                Description = vm.Description
            };
            
        }
    }
}
