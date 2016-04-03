using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Repository.Model;

namespace EF_Repository.Data
{
    class HitLogsRepository:IDisposable
    {
        private EfContext _entity;

        public HitLogsRepository(EfContext entity)
        {
            _entity = entity;
        }

        public void Add(HitLog entity)
        {
            _entity.HitLogs.Add(entity);
        }

        public void Delete(HitLog entity)
        {
            _entity.HitLogs.Remove(entity);
        }
        public HitLog[] GetHitLogs()
        {
            return _entity.HitLogs.ToArray();
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
