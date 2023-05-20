using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory.ViewModel.Customer
{
    public class CreateCustomerViewModel
    {
       
        [Required]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZioCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public Inventory.Models.Customer Convert(CreateCustomerViewModel vm)
        {
            var model = new Inventory.Models.Customer();
            model.CustomerName = vm.CustomerName;
            model.CustomerTypeId = vm.CustomerTypeId;
            model.Address = vm.Address;
            model.City = vm.City;
            model.State = vm.State;
            model.ZioCode = vm.ZioCode;
            model.Phone = vm.Phone;
            model.Email = vm.Email;
            model.ContactPerson = vm.ContactPerson;
            return model;
           
           
        }
    }
}
