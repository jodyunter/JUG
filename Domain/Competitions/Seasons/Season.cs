using Domain.Games;
using Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Competitions.Seasons
{
    public class Season : Competition
    {         

        public override void ProcessGame(IGame game)
        {
            if (game.IsComplete)
            {
                var homeTeam = (SeasonTeam)Teams.Where(t => t.Id == game.Home.Id).FirstOrDefault();
                var awayTeam = (SeasonTeam)Teams.Where(t => t.Id == game.Away.Id).FirstOrDefault();

                AddStats(homeTeam, game.HomeStats, game.AwayStats);
                AddStats(awayTeam, game.AwayStats, game.HomeStats);
            }

        }

        public void AddStats(SeasonTeam team, IGameTeamStats stats, IGameTeamStats opponent)
        {
            team.GoalsFor += stats.Score;
            team.GoalsAgainst += opponent.Score;
            team.ShotsFor += stats.Shots;
            team.ShotsAgainst += opponent.Shots;
            
            if (opponent.Score < stats.Score)
            {
                team.Wins++;
            }
            else if (opponent.Score > stats.Score)
            {
                team.Loses++;
            }
            else
            {
                team.Ties++;
            }
        }

        public override void SetRankings()
        {
            //we currently have no division options
            var list = new List<SeasonTeam>();

            Teams.ToList().ForEach(team =>
            {
                list.Add((SeasonTeam)team);
            });

            list.Sort();

            Rankings = new List<IRanking>();
          
            int i = 1;

            list.ForEach(team =>
            {
                Rankings.Add(new SeasonRanking() { Group = "Standings", Rank = 1, Team = team });
            });
        }
    }
}
