using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuantMarketing.Repositories;
using QuantMarketing.Repositories.Accounts;
using QuantMarketing.Shared.Models;

namespace QuantMarketing.Service.Controllers
{
    //TODO implement async await for actions

    public class AccountController : ApiController
    {
        private readonly IUnitOfWork _accountUnitOfWork;

        //TODO implement DI and let DI pass the correct object. then we dont need the default constructor
        public AccountController(IUnitOfWork accountUnitOfWork)
        {
            _accountUnitOfWork = accountUnitOfWork;
        }

        public AccountController()
        {
            _accountUnitOfWork = new DbUow();
        }
        // GET api/<controller>
        public IEnumerable<Account> Get(string market)
        {
            if (market.ToLower() == "kr")
                return _accountUnitOfWork.AccountRequest.List(x => x.Status == "Active" && x.Market.ToLower() == market.ToLower());

            return _accountUnitOfWork.AccountRequest.List(x => x.Market.ToLower() == market.ToLower());
        }

        // GET api/<controller>
        public IEnumerable<Account> Get()
        {
            return _accountUnitOfWork.AccountRequest.List();
        }

        // GET api/<controller>/5
        public Account Get(int id)
        {
            return _accountUnitOfWork.AccountRequest.Find(id);
        }

        // POST api/<controller>
        
        public void Post([FromUri]Account account)
        {
            _accountUnitOfWork.AccountRequest.Save(account);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _accountUnitOfWork.AccountRequest.Delete(id);
        }
    }
}