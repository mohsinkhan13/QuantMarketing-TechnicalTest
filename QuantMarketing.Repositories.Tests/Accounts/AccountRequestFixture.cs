using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QuantMarketing.Repositories.Accounts;
using QuantMarketing.Shared.Models;

namespace QuantMarketing.Repositories.Tests.Accounts
{
    [TestFixture]
    public class AccountRequestFixture
    {
        [Test]
        public void ListReturns10ItemsOfTypeAccount()
        {
            var request = new AccountRequest();

            var list = request.List();

            Assert.AreEqual(10, list.Count());
            Assert.IsInstanceOf<List<Account>>(list);
        }

        [Test]
        public void ListReturns5ItemsOfStatusInActive()
        {
            const int expectedCount = 5;
            const string filterStatus = "InActive";
            var request = new AccountRequest();

            var list = request.List(x=>x.Status == filterStatus);

            Assert.AreEqual(expectedCount, list.Count());
        }

        [Test]
        public void FindReturnsAccountWithId5()
        {
            const int expectedId = 5;
            var request = new AccountRequest();

            var account = request.Find(expectedId);

            Assert.AreEqual(expectedId, account.Id);
        }

        [Test]
        public void FindReturnsNullForIdNotFound()
        {
            const int unavaibleId = 11;
            var request = new AccountRequest();

            var account = request.Find(unavaibleId);

            Assert.IsNull(account);
        }

        [Test]
        public void DeleteRemovesAccountWithId5()
        {
            const int accountIdToDelete = 5;
            const int expectedListCount = 9;

            var request = new AccountRequest();

            request.Delete(accountIdToDelete);

            var list = request.List();

            Assert.AreEqual(expectedListCount, list.Count());
        }

        [Test]
        public void DeleteDoesNothingForIdNotFound()
        {
            const int notAvailableIdToDelete = 11;
            const int expectedListCount = 10;

            var request = new AccountRequest();

            request.Delete(notAvailableIdToDelete);

            var list = request.List();

            Assert.AreEqual(expectedListCount, list.Count());
        }

        [Test]
        public void NullAccountObjectsDoNotGetSaved()
        {
            const Account newNullAccount = null;
            const int expectedListCount = 10;
            var request = new AccountRequest();

            request.Save(newNullAccount);

            var list = request.List();

            Assert.AreEqual(expectedListCount, list.Count());
        }

        [Test]
        public void AccountWithZeroIdDoNotGetSaved()
        {
            var newAccount = new Account();
            const int expectedListCount = 10;
            var request = new AccountRequest();

            request.Save(newAccount);

            var list = request.List();

            Assert.AreEqual(expectedListCount, list.Count());
        }

        [Test]
        public void AccountWithExistingIdDoNotGetSaved()
        {
            var newAccount = new Account{Id = 2};
            const int expectedListCount = 10;
            var request = new AccountRequest();

            request.Save(newAccount);

            var list = request.List();

            Assert.AreEqual(expectedListCount, list.Count());
        }
    }
}
