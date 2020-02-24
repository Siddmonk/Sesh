using SeshDB.Data.Sesh;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sesh.Data
{
    public class TransactionService
    {
        private readonly SeshContext _context;
        public TransactionService(SeshContext context)
        {
            _context = context;
        }
        public async Task<List<Transactions>>
            GetTransactionsAsync(string strCurrentUser)
        {
            return await _context.Transactions
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
        public Task<Transactions>
            CreateTransactionAsync(Transactions objTransaction)
        {
            _context.Transactions.Add(objTransaction);
            _context.SaveChanges();
            return Task.FromResult(objTransaction);
        }
    }
}
