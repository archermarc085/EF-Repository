using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Repository.Model;

namespace EF_Repository.Data
{
    class TransactionsRepository:IDisposable
    {
        private EfContext _entity;

        public TransactionsRepository(EfContext entity)
        {
            _entity = entity;
        }

        public void Add(Transcation entity)
        {
            _entity.Transactions.Add(entity);
        }

        public void Delete(Transcation entity)
        {
            _entity.Transactions.Remove(entity);
        }

        public void SaveChanges()
        {
            _entity.SaveChanges();
        }

        public void Dispose()
        {
            if (_entity != null)
            {
                _entity.Dispose();
            }
        }
    }
}
