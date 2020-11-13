﻿namespace Domain.Teams
{
    public class Team_League : Team
    {
        public int Wins
        {get; set;} = 0;

        public int Draws
        {get; set;} = 0;

        public int Losses
        {get; set;} = 0;

        public int Points
        { get{return (Wins*3) + Draws;} }

        public int GoalsFor
        {get; set;} = 0;

        public int GoalsAgainst
        {get; set;} = 0;

        public int GoalDifference
        { get{return GoalsFor - GoalsAgainst;} }

        public Team_League CurrentOpponent
        {get; set;} = null;

        public bool HasPlayed
        {get; set;} = false;

        public Team_League(Team team) : base(team.Name, team.Players)
        {}
    }
}
