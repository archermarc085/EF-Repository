using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Repository.Model;

namespace EF_Repository.Data
{
    class CombatsRepository:IDisposable
    {
        private EfContext _entity;

        public CombatsRepository(EfContext entity)
        {
            _entity = entity;
        }

        public void Add(Combat entity)
        {
            _entity.Combats.Add(entity);
        }

        public void Delete(Combat entity)
        {
            _entity.Combats.Remove(entity);
        }
        public Combat[] GetCombats()
        {
            return _entity.Combats.ToArray();
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
