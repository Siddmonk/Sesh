using SeshDB.Data.Sesh;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sesh.Data
{
    public class BudgetService
    {
        private readonly SeshContext _context;
        public BudgetService(SeshContext context)
        {
            _context = context;
        }
        public async Task<List<BudgetedItems>>
            GetBudgetItemAsync(string strCurrentUser)
        {
            return await _context.BudgetedItems
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
    }
}
