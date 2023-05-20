using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerService
{
    public interface ICustomerRepo
    {
        PagedResult<CustomerViewModel> GetAll(int pageSize, int PageNumber);
        void Add(CreateCustomerViewModel model);
        void Update(CustomerViewModel model);
        void Delete(int id);
        CustomerViewModel GetById(int id);
    }
}
