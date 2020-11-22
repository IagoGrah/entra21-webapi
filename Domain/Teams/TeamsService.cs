using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Players;

namespace Domain.Teams
{
    public class TeamsService
    {
        // private readonly TeamsRepository _teamsRepository = new TeamsRepository();
        
        // public CreatedTeamDTO Create(string name)
        // {
        //     var team = new Team(name);
        //     // var teamVal = team.Validate();

        //     // if (!teamVal.isValid)
        //     // {
        //     //     return new CreatedTeamDTO(teamVal.errors);
        //     // }
            
        //     _teamsRepository.Add(team);
        //     return new CreatedTeamDTO(team.Id);
        // }

        // public Team GetByID(Guid id)
        // {
        //     return _teamsRepository.GetByID(id);
        // }

        // public IEnumerable<Team> GetAll()
        // {
        //     return _teamsRepository.GetAll();
        // }
    }
}
