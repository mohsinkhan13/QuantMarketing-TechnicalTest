using QuantMarketing.Shared.Models;

namespace QuantMarketing.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Account> AccountRequest { get; }
    }
}