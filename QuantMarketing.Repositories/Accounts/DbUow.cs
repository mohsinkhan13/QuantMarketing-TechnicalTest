using QuantMarketing.Shared.Models;

namespace QuantMarketing.Repositories.Accounts
{
    public class DbUow : IUnitOfWork
    {
        private IRepository<Account> _accountRequest;

        public IRepository<Account> AccountRequest
        {
            get
            {
                if (this._accountRequest == null)
                {
                    this._accountRequest = new AccountRequest();
                }
                return _accountRequest;

            }
        }
        
    }
}