using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tables
{
    public class Table : ITable
    {
        public string Heading { get; set;}
        public IList<IRanking> Rankings { get; set; }

        public int CompareTeams(ITableTeam a, ITableTeam b)
        {
            int pts = a.Points.CompareTo(b.Points);

            if (pts == 0)
            {
                int games = a.GamesPlayed.CompareTo(b.GamesPlayed);
                if (games == 0)
                {
                    int wins = a.Wins.CompareTo(b.Wins);

                    if (wins == 0)
                    {
                        int gd = a.GoalDifference.CompareTo(b.GoalDifference);

                        if (gd == 0)
                        {
                            int rw = a.RegulationWins.CompareTo(b.RegulationWins);

                            if (rw == 0)
                            {
                                int goals = a.GoalsFor.CompareTo(b.GoalsFor);

                                return goals;
                            }
                            return rw;
                        }
                        return gd;
                    }
                    return wins;
                }
                return games * -1; //lower is better
            }
            return pts; //reverse this one
        }

        public void SortStandings(string byGroup)
        {
            throw new NotImplementedException();
        }

        public void SortStandings()
        {
            throw new NotImplementedException();
        }
    }
}
