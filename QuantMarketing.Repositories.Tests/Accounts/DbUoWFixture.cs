using NUnit.Framework;
using QuantMarketing.Repositories.Accounts;
using QuantMarketing.Shared.Models;

namespace QuantMarketing.Repositories.Tests.Accounts
{
    [TestFixture]
    public class DbUoWFixture
    {
        [Test]
        public void PropertyReturnsIRepositoryOfTypeAccountRequest()
        {
            var dbUow = new DbUow();

            var repository = dbUow.AccountRequest;

            Assert.IsInstanceOf<AccountRequest>(repository);

        }
    }
}