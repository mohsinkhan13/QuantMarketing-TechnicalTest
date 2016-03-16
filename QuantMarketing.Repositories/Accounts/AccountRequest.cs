using System;
using System.Collections.Generic;
using System.Linq;
using QuantMarketing.Shared.Models;

namespace QuantMarketing.Repositories.Accounts
{
    public class AccountRequest : IRepository<Account>
    {
        private readonly List<Account> _accounts;

        public AccountRequest()
        {
            _accounts = GetInMemoryAccounts();
        }

        public IEnumerable<Account> List(Func<Account, bool> filter = null)
        {
            if (filter != null) 
                return _accounts.Where(filter).ToList();

            return _accounts;
        }
        
        public Account Find(int id)
        {
            return _accounts.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var account = Find(id);
            if (account != null)
                _accounts.Remove(account);
        }

        public void Save(Account newAccount)
        {
            if (newAccount == null || newAccount.Id <= 0) return;

            if (Find(newAccount.Id) != null) return;
            
            _accounts.Add(newAccount);
        }

        private List<Account> GetInMemoryAccounts()
        {
            return new List<Account>
            {
                new Account {Id = 1, Market = "GB", Status = "InActive"},
                new Account {Id = 2, Market = "Kr", Status = "InActive"},
                new Account {Id = 3, Market = "GB", Status = "InActive"},
                new Account {Id = 4, Market = "Kr", Status = "InActive"},
                new Account {Id = 5, Market = "GB", Status = "InActive"},
                new Account {Id = 6, Market = "Kr", Status = "Active"},
                new Account {Id = 7, Market = "GB", Status = "Active"},
                new Account {Id = 8, Market = "Kr", Status = "Active"},
                new Account {Id = 9, Market = "GB", Status = "Active"},
                new Account {Id = 10, Market = "Kr", Status = "Active"}
            };
        }

    }

}