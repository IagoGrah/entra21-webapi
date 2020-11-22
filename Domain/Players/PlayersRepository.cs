using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Infra;

namespace Domain.Players
{
    class PlayersRepository
    {
        public void Add(Player player)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Players.Add(player);
                db.SaveChanges();
            }
        }

        public Guid? Remove(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                var player = db.Players.FirstOrDefault(x => x.Id == id);
                if (player == null) {return null;}
                db.Players.Remove(player);
                db.SaveChanges();
                return id;
            }
        }

        public Player GetByID(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Players.FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<Player> GetAll()
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Players;
            }
        }
    }
}
