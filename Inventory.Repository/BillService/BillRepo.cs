using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillService
{
    public class BillRepo : IBillRepo
    {
        private ApplicationDbContext _context;

        public BillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int PageNumber)
        {
            var bills = _context.Bills;
            var vm = bills.ModelToVM().AsQueryable();
            return await PaginatedList<BillListViewModel>.CreateAsync(vm, PageNumber, pageSize);

        }
    }
}
