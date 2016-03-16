using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QuantMarketing.Service.Controllers;
using QuantMarketing.Shared.Models;


namespace QuantMarketing.Service.Tests.Controllers
{
    [TestFixture]
    class AccountControllerFixture
    {
        //TODO use Moq framework to mock UnitOfWork object. but since we are only working with
        //TODO in-memory Account repository for this assignment. This may not be neccesary 
        [Test]
        public void GetReturnsListSize10()
        {
            var con = new AccountController();
            var list = con.Get();
            Assert.AreEqual(10,list.Count());
        }
        
        [Test]
        public void GetForMarketReturnsListSize3()
        {
            var con = new AccountController();
            var list = con.Get("Kr");
            
            Assert.AreEqual(3, list.Count());
        }

        [Test]
        public void GetForMarketReturnsListSize5()
        {
            var con = new AccountController();
            var list = con.Get("GB");

            Assert.AreEqual(5, list.Count());
        }

        [Test]
        public void GetForId2ReturnsAccountObjectOfId2()
        {
            var con = new AccountController();
            var account = con.Get(2);

            Assert.IsInstanceOf<Account>(account);
            Assert.IsNotNull(account);

        }

        [Test]
        public void GetForId11ReturnsNull()
        {
            var con = new AccountController();
            var account = con.Get(11);

            Assert.IsNull(account);

        }

        [Test]
        public void DeletesAccountWithValidId()
        {
            var con = new AccountController();
            con.Delete(1);

            var list = con.Get();
            var account = list.FirstOrDefault(x => x.Id == 1);

            Assert.AreEqual(9, list.Count());
            Assert.IsNull(account);
        }

        [Test]
        public void AccountNotDeletedWhenIdNotFound()
        {
            var con = new AccountController();
            con.Delete(11);

            var list = con.Get();

            Assert.AreEqual(10, list.Count());
        }

        [Test]
        public void PostSavesNewAccount()
        {
            var newAccount = new Account {Id = 11, Market = "USA", Status = "Active"};
            var con = new AccountController();
            con.Post(newAccount);

            var list = con.Get();

            Assert.AreEqual(11, list.Count());
        }

        [Test]
        public void PostDoesNotSavesNullObject()
        {
            Account newAccount = null;
            var con = new AccountController();
            con.Post(newAccount);

            var list = con.Get();

            Assert.AreEqual(10, list.Count());
        }

        [Test]
        public void PostDoesNotAccountWithSameId()
        {
            Account newAccount = new Account { Id = 5, Market = "USA", Status = "Active" };
            var con = new AccountController();
            con.Post(newAccount);

            var list = con.Get();
            var resultForAccountId5 = list.Where(x => x.Id == 5);

            Assert.AreEqual(10, list.Count());
            Assert.AreEqual(1, resultForAccountId5.Count());
        }


    }
}
