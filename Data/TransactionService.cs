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
        public Task<bool>
            UpdateTransactionAsync(Transactions objTransaction)
        {
            var ExistingTransaction = _context.Transactions
                .Where(x => x.TransactionId == objTransaction.TransactionId)
                .FirstOrDefault();
            if (ExistingTransaction != null)
            {
                ExistingTransaction.AccountId = objTransaction.AccountId;
                ExistingTransaction.TransactionDate = objTransaction.TransactionDate;
                ExistingTransaction.PayeeId = objTransaction.PayeeId;
                ExistingTransaction.ItemId = objTransaction.ItemId;
                ExistingTransaction.Memo = objTransaction.Memo;
                ExistingTransaction.DebitAmount = objTransaction.DebitAmount;
                ExistingTransaction.CreditAmount = objTransaction.CreditAmount;                
                var results = _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool>
            DeleteTransactionAsync(Transactions transaction)
        {
            var ExistingTransaction = _context.Transactions
                .Where(x => x.TransactionId == transaction.TransactionId)
                .FirstOrDefault();
            if (ExistingTransaction != null)
            {
                _context.Transactions.Remove(ExistingTransaction);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
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
        public Task<Accounts>
            CreateAccountAsync(Accounts objAccount)
        {
            _context.Accounts.Add(objAccount);
            _context.SaveChanges();
            return Task.FromResult(objAccount);
        }
        public Task<bool>
            UpdateAccountAsync(Accounts objAccount)
        {
            var ExistingAccount = _context.Accounts
                .Where(x => x.AccountId == objAccount.AccountId)
                .FirstOrDefault();
            if (ExistingAccount != null)
            {
                ExistingAccount.AccountName = objAccount.AccountName;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        public Task<bool>
            DeleteAccountAsync(Accounts account)
        {
            var ExistingAccount = _context.Accounts
                .Where(x => x.AccountId == account.AccountId)
                .FirstOrDefault();
            if (ExistingAccount != null)
            {
                _context.Accounts.Remove(ExistingAccount);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
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
        public Task<bool>
            UpdatePayeeAsync(Payees objPayee)
        {
            var ExistingPayee = _context.Payees
                .Where(x => x.PayeeId == objPayee.PayeeId)
                .FirstOrDefault();
            if (ExistingPayee != null)
            {
                ExistingPayee.PayeeName = objPayee.PayeeName;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
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
        public Task<bool>
            UpdateClassAsync(Classifications objClassification)
        {
            var ExistingClassification = _context.Classifications
                .Where(x => x.ClassId == objClassification.ClassId)
                .FirstOrDefault();
            if (ExistingClassification != null)
            {
                ExistingClassification.ClassName = objClassification.ClassName;
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
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
        public Task<bool>
            UpdateCategoryAsync(Categories objCategory)
        {
            var ExistingCategory = _context.Categories
                .Where(x => x.ItemId == objCategory.ItemId)
                .FirstOrDefault();
            if (ExistingCategory != null)
            {
                ExistingCategory.BudgetItemName = objCategory.BudgetItemName;
                ExistingCategory.BudgetedAmount = objCategory.BudgetedAmount;
                ExistingCategory.ClassId = objCategory.ClassId;
                ExistingCategory.CurrentBalance = objCategory.CurrentBalance;
                ExistingCategory.LastActiveMonth = objCategory.LastActiveMonth;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
