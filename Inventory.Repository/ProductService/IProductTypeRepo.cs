using Inventory.Repository.Paging;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductService
{
    public interface IProductTypeRepo
    {
        PagedResult<ProductTypeViewModel> GetAll(int pageNumber, int pageSize);

        void Add(CreateProductTypeViewModel model);
        void Update(ProductTypeViewModel model);
        void Delete(int id);
        ProductTypeViewModel GetById(int id);

    }
}
