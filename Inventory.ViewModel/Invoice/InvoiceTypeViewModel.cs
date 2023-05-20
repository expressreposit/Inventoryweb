using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Invoice
{
    public class InvoiceTypeViewModel
    {
        public int InvoiceTypeId { get; set; }

        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
        public InvoiceTypeViewModel(InvoiceType model)
        {

            InvoiceTypeId = model.InvoiceTypeId;
            InvoiceTypeName = model.InvoiceTypeName;
            Description = model.Description;
        }

    }
}
