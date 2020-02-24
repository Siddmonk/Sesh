using SeshDB.Data.Sesh;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sesh.Data
{
    public class PayeeService
    {
        private readonly SeshContext _context;
        public PayeeService(SeshContext context)
        {
            _context = context;
        }
        public async Task<List<Payees>>
            GetPayeesAsync(string strCurrentUser)
        {
            return await _context.Payees
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
    }
}
