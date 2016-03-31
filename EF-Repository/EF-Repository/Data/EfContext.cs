using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Repository.Model;

namespace EF_Repository.Data
{
    class EfContext:DbContext
    {
        public EfContext()
            : base("CombatDb")
        {
            
        }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Combat> Combats { get; set; }
        public virtual DbSet<HitLog> HitLogs { get; set; }
        public virtual DbSet<Transcation> Transactions { get; set; }
    }
}
