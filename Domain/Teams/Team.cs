using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Players;

namespace Domain.Teams
{
    public class Team : Entity
    {
        public string Name
        {get; protected set;}

        public List<Player_Team> Players
        {get; set;}

        public Team(string name, List<Player> players)
        {
            Name = name;
            Players = players.Select(x => new Player_Team(x, this)).ToList();
        }

        protected Team(string name, List<Player_Team> players)
        {
            Name = name;
            Players = players;
        }

        public Team(string name)
        {
            Name = name;
        }
    }
}
