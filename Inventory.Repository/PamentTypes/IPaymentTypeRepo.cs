using Inventory.Repository.Paging;
using Inventory.ViewModel.PaymentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.PamentTypes
{
    public interface IPaymentTypeRepo
    {
        PagedResult<PaymentTypeViewModel> GetAll(int pageNumber, int pageSize);

        void Add(CreatePaymentTypeViewModel model);
        void Update(PaymentTypeViewModel model);
        void Delete(int id);
        PaymentTypeViewModel GetById(int id);

    }
}
