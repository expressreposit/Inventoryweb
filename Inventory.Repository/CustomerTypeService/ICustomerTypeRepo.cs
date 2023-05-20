using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerTypeService
{
    public interface ICustomerTypeRepo
    {
        PagedResult<CustomerTypeListViewModel> GetAll(int pageSize,int PageNumber);
        void Add(CreateCustomerTypeViewModel model);
        void Update(CustomerTypeViewModel model);
        void Delete(int id);
        CustomerTypeViewModel GetById(int id);
        IEnumerable<CustomerTypeListViewModel> GetALLWithoutPaging();
        PagedResult<CustomerTypeListViewModel> Search(string searching, int pageSize, int pageNumber);
    }
}
