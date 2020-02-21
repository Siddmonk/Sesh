using SeshDB.Data.Sesh;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sesh.Data
{
    public class AccountService
    {
        private readonly SeshContext _context;
        public AccountService(SeshContext context)
        {
            _context = context;
        }
        public async Task<List<Accounts>>
            GetAccountsAsync(string strCurrentUser)
        {
            return await _context.Accounts
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
    }
}
