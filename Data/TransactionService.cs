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


        //Transaction Services

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


        //Account Services

        public async Task<List<Accounts>>
            GetAccountsAsync(string strCurrentUser)
        {
            return await _context.Accounts
                .Where(x => x.UserName == strCurrentUser)
            .AsNoTracking().ToListAsync();
        }
        public async Task<Dictionary<int, string>>
            GetAccountKeyValuesAsync(string strCurrentUser)
        {
            return await _context.Accounts
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToDictionaryAsync(e => e.AccountId, f => f.AccountName);
        }


        // Payee Services

        public async Task<List<Payees>>
            GetPayeesAsync(string strCurrentUser)
        {
            return await _context.Payees
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
        public async Task<Dictionary<int, string>>
            GetPayeeKeyValuesAsync(string strCurrentUser)
        {
            return await _context.Payees
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToDictionaryAsync(e => e.PayeeId, f => f.PayeeName);
        }


        // Classification Services

        public async Task<List<Classifications>>
            GetClassificationsAsync(string strCurrentUser)
        {
            return await _context.Classifications
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
        public async Task<Dictionary<int, string>>
            GetClassKeyValuesAsync(string strCurrentUser)
        {
            return await _context.Classifications
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToDictionaryAsync(e => e.ClassId, f => f.ClassName);
        }


        // Category Services

        public async Task<List<Categories>>
            GetCategoriesAsync(string strCurrentUser)
        {
            return await _context.Categories
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToListAsync();
        }
        public async Task<Dictionary<int, string>>
            GetCatKeyValuesAsync(string strCurrentUser)
        {
            return await _context.Categories
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking().ToDictionaryAsync(e => e.ItemId, f => f.BudgetItemName);
        }
    }
}
