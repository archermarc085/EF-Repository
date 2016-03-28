using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Repository.Model;

namespace EF_Repository.Data
{
    class DBInitializer
    {
        public static void AddEntityGraph()
        {
            var newPlayer = new Player() { Login = "New Player",Password = "000",Email = "plyaer@mail.ru",IsValidEmail = false,  Date = new DateTime(2010, 1, 10) };
            newPlayer.Combat = new Combat() { CombatType = "PVE", CombatId = 1, Winner = "Bot",HitLog = new HitLog() { FirstPlayerHitValue = 60, SecondPlayerHitValue = 100, FirstPlayerName = newPlayer.Login, SecondPlayerName = "Bot" } };
            newPlayer.Transactions.Add(new Transcation() { PlayerId = newPlayer.PlayerId, Player = newPlayer,  Sum = 20, Date = new DateTime(2010, 1, 12) });
            using (var entity = new EfContext())
            {
                UnitOfWork unitOfWork = new UnitOfWork(entity);
                unitOfWork.PlayersRepo.Add(newPlayer);
                try
                {
                    entity.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine(@"Entity of type \{0}\ in state \{1}\ has the
                                 following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                catch (DbUpdateException e)
                {
                    Debug.WriteLine(e.Entries);
                    var exception = HandleDbUpdateException(e);
                    throw exception;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }
            }

        }
        private static Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }

        public static void AddEntityGraphs()
        {
            var player = new Player() { PlayerId =  2 ,Login = "archer", Email = "archer@gmail.com", Password = "777", IsValidEmail = true, Date = new DateTime(2010, 2, 11)};
            var player1 = new Player() { PlayerId = 3, Login = "mike", Email = "mike@gmail.com", Password = "qwerty", IsValidEmail = true, Date = new DateTime(2010, 2, 11) };
           
            player.Combat = new Combat()
            {
                CombatType = "PVE",
                Date = new DateTime(2010, 2, 11),
                CombatId = 2, Winner = player.Login ,
                HitLog =
                    new HitLog()
                    {
                        FirstPlayerHitValue = 100,
                        SecondPlayerHitValue = 80,
                        FirstPlayerName = player.Login,
                        SecondPlayerName = "Bot"
                    }

            };

            player1.Combat = new Combat()
            {
                CombatType = "PVE",
                Date = new DateTime( 2010, 2, 11),
                CombatId = 3,
                Winner = player1.Login,
                HitLog =
                    new HitLog()
                    {
                        FirstPlayerHitValue = 100,
                        SecondPlayerHitValue = 90,
                        FirstPlayerName = player1.Login,
                        SecondPlayerName = "Bot"
                    }

            };


            player.Transactions.Add(new Transcation()
            {
                PlayerId = player.PlayerId,
                Player = player,
                Sum = 30,
                Date = new DateTime(2010, 1, 12)
            });

            player1.Transactions.Add(new Transcation()
            {
                PlayerId = player.PlayerId,
                Player = player1,
                Sum = 20,
                Date = new DateTime(2010, 1, 12)
            });
            using (var entity = new EfContext())
            {
                UnitOfWork unitOfWork = new UnitOfWork(entity);
                unitOfWork.PlayersRepo.Add(player);
                unitOfWork.PlayersRepo.Add(player1);
                entity.SaveChanges();
            }
        }
    }
}
