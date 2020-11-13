using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Players;

namespace Domain.Teams
{
    public class TeamsService
    {
        public CreatedTeamDTO Create(string name)
        {
            // var players = playerIds.Select(x => GetByID(x)).ToList();
            
            var team = new Team(name);
            // var teamVal = team.Validate();

            // if (!teamVal.isValid)
            // {
            //     return new CreatedPlayerDTO(playerVal.errors);
            // }
            
            TeamsRepository.Add(team);
            return new CreatedTeamDTO(team.Id);
        }

        public IEnumerable<Team> GetAll()
        {
            return TeamsRepository.Teams as IEnumerable<Team>;
        }

        public Player GetByID(Guid id)
        {
            return PlayersRepository.Players.FirstOrDefault(x => x.Id == id);
        }
    }
}
