using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Invoice
{
    public class CreateInvoiceTypeViewModel
    {
        

        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }
        public InvoiceType Convert(CreateInvoiceTypeViewModel model)
        {
            var invoiceType = new InvoiceType();
            invoiceType.InvoiceTypeName = model.InvoiceTypeName;
            invoiceType.Description = model.Description;
            return invoiceType;
        }

    }
}
