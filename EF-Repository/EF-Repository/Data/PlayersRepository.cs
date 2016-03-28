using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Repository.Model;

namespace EF_Repository.Data
{
    class PlayersRepository:IDisposable
    {
        private EfContext _entity;

        public PlayersRepository(EfContext entity)
        {
            _entity = entity;
        }

        public void Add(Player entity)
        {
            _entity.Players.Add(entity);
        }

        public void Delete(Player entity)
        {
            _entity.Players.Remove(entity);
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
