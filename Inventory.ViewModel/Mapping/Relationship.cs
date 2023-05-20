using Inventory.Models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {
        public static IEnumerable<CustomerTypeListViewModel> 
            ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> list =  new List<CustomerTypeListViewModel>();
            foreach (var ct in customerType)
            {
             list.Add(new CustomerTypeListViewModel()
                 {
                 CustomerTypeId = ct.CustomerTypeId,
                 CustomerTypeName = ct.CustomerTypeName,
                 Description = ct.Description
             });
            }
            return list;
        }


        public static IEnumerable<CustomerListViewModel>
            ModelToVM(this IEnumerable<Inventory.Models.Customer> customers)
        {
            List<CustomerListViewModel> list = new List<CustomerListViewModel>();
            foreach (var ct in customers)
            {
                list.Add(new CustomerListViewModel()
                {
                    CustomerId = ct.CustomerId,
                    CustomerName= ct.CustomerName,
                    City=ct.City,
                    ContactPerson=ct.ContactPerson,
                    CustomerTypeId=ct.CustomerTypeId,
                    ZioCode=ct.ZioCode,
                    Address=ct.Address,
                    Email=ct.Email, 
                    Phone=ct.Phone,
                    State=ct.State

                   
                });
            }
            return list;
        }



        public static IQueryable<BillTypeListViewModel>
           ModelToVM(this IQueryable<BillType> billTypes)
        {
            List<BillTypeListViewModel> list = new List<BillTypeListViewModel>();
            foreach (var ct in billTypes)
            {
                list.Add(new BillTypeListViewModel()
                {
                    BillTypeId=ct.BillTypeId,
                    BillTypeName=ct.BillTypeName,
                    Description=ct.Description
                });
            }
            return list.AsQueryable();
        }


        public static IEnumerable<BillListViewModel>
           ModelToVM(this IEnumerable<Inventory.Models.Bill> bills)
        {
            List<BillListViewModel> list = new List<BillListViewModel>();
            foreach (var ct in bills)
            {
                list.Add(new BillListViewModel()
                {
                   BillDate=ct.BillDate,
                   BillDueDate=ct.BillDueDate,
                   BillId=ct.BillId,
                   BillName=ct.BillName,
                   BillTypeId=ct.BillTypeId,
                   GoodsReceivedNoteId=ct.GoodsReceivedNoteId,
                   VendorDoNumber=ct.VendorDoNumber,
                   VendorInvoiceNumber=ct.VendorInvoiceNumber
                  

                });
            }
            return list;
        }



        public static IEnumerable<ProductTypeListViewModel>
          ModelToVM(this IEnumerable<ProductType> productTypes)
        {
            List<ProductTypeListViewModel> list = new List<ProductTypeListViewModel>();
            foreach (var ct in productTypes)
            {
                list.Add(new ProductTypeListViewModel()
                {
                    ProductTypeId=ct.ProductTypeId,
                    ProductTypeName=ct.ProductTypeName,
                    Description=ct.Description,


                });
            }
            return list;
        }




    }
}
