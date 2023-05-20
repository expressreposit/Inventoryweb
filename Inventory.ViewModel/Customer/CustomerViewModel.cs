using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory.ViewModel.Customer
{
    public class CustomerViewModel
    {
       

        public CustomerViewModel(Models.Customer model)
        {
            this.CustomerId = model.CustomerId;
            this.CustomerName = model.CustomerName;
            this.CustomerTypeId = model.CustomerTypeId;
            this.Address = model.Address;
            this.City = model.City;
            this.State = model.State;
            this.ZioCode = model.ZioCode;
            this.Phone = model.Phone;
            this.Email = model.Email;
            this.ContactPerson = model.ContactPerson;
          
        }

        public int CustomerId { get; set; }
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

    }
}
