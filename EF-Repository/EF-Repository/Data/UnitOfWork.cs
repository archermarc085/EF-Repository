using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Repository.Data
{
    class UnitOfWork
    {
        PlayersRepository _playersRepo;
        CombatsRepository _combatsRepo;
        TransactionsRepository _transactionsRepo;
        HitLogsRepository _hitLogsRepo;
        private EfContext _entity;

        public UnitOfWork(EfContext context)
        {
            _entity = context;
        }


        public PlayersRepository PlayersRepo
        {
            get
            {
                if (_playersRepo == null)
                {
                    _playersRepo = new PlayersRepository(_entity);
                }
                return _playersRepo;
            }
        }

        public CombatsRepository CombatsRepo
        {
            get
            {
                if (_combatsRepo == null)
                {
                    _combatsRepo = new CombatsRepository(_entity);
                }
                return _combatsRepo;
            }
        }

        public TransactionsRepository TransactionsRepo
        {
            get
            {
                if (_transactionsRepo == null)
                {
                    _transactionsRepo = new TransactionsRepository(_entity);
                }
                return _transactionsRepo;
            }
        }

        public HitLogsRepository HitLogsRepo
        {
            get
            {
                if (_hitLogsRepo == null)
                {
                    _hitLogsRepo = new HitLogsRepository(_entity);
                }
                return _hitLogsRepo;
            }
        }


        public void Save()
        {
            _entity.SaveChanges();
        }
    }
}
