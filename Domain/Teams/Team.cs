using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Players;

namespace Domain.Teams
{
    public class Team
    {
        public Guid Id
        {get; set;} = Guid.NewGuid();
        
        public string TeamName
        {get; protected set;}

        public List<Player_Team> Players
        {get; set;}

        public Team(string name, List<Player> players)
        {
            TeamName = name;
            Players = players.Select(x => new Player_Team(x, this)).ToList();
        }

        protected Team(string name, List<Player_Team> players)
        {
            TeamName = name;
            Players = players;
        }
    }
}
