using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using QuantMarketing.Shared.Models;

namespace QuantMarketing.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> List(Func<T, bool> filter = null);
        T Find(int id);
        void Delete(int id);
        void Save(Account newAccount);
    }
}