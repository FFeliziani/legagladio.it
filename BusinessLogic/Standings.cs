using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace BusinessLogic
{
    public static class Standings
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static IOrderedEnumerable<LegaGladio.Entities.Standings> GetStandings(LegaGladio.Entities.Series series)
        {
            try
            {
                var standings = new List<LegaGladio.Entities.Standings>();
                var games = Game.ListGame(series);
                return GetStandings(games, standings);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error calculating standings for season");
                throw;
            }
        }

        public static IOrderedEnumerable<LegaGladio.Entities.Standings> GetStandings(LegaGladio.Entities.Group group)
        {
            try
            {
                var standings = new List<LegaGladio.Entities.Standings>();
                var games = Game.ListGame(group);
                return GetStandings(games, standings);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error calculating standings for season");
                throw;
            }
        }

        private static IOrderedEnumerable<LegaGladio.Entities.Standings> GetStandings(ICollection<LegaGladio.Entities.Game> games, List<LegaGladio.Entities.Standings> standings)
        {
            foreach (var game in games)
            {
                if (!(game.GameDate != null | game.GameDate < DateTime.Now)) continue;
                var standingHome =
                    standings.SingleOrDefault(x => x.Team != null && x.Team.Id == game.Home.Id) ??
                    new LegaGladio.Entities.Standings();
                var standingGuest =
                    standings.SingleOrDefault(x => x.Team != null && x.Team.Id == game.Guest.Id) ??
                    new LegaGladio.Entities.Standings();
                standingHome.Team = game.Home;
                standingGuest.Team = game.Guest;
                standingHome.GamesPlayed += 1;
                standingGuest.GamesPlayed += 1;
                if (game.TdHome > game.TdGuest)
                {
                    standingHome.Wins++;
                    standingGuest.Losses++;
                }
                else if (game.TdGuest > game.TdHome)
                {
                    standingGuest.Wins++;
                    standingHome.Losses++;
                }
                else
                {
                    standingGuest.Draws++;
                    standingHome.Draws++;
                }
                standingHome.CasFor += game.CasHome;
                standingHome.CasAgainst += game.CasGuest;
                standingGuest.CasFor += game.CasGuest;
                standingGuest.CasAgainst += game.CasHome;
                standingHome.TdFor += game.TdHome;
                standingHome.TdAgainst += game.TdGuest;
                standingGuest.TdFor += game.TdGuest;
                standingGuest.TdAgainst += game.TdHome;
                standingHome.Points = (standingHome.Wins*5) + (standingHome.Draws*2);
                standingGuest.Points = (standingGuest.Wins*5) + (standingGuest.Draws*2);
                standingHome.Delta1 = (standingHome.TdFor - standingHome.TdAgainst) +
                                      (standingHome.CasFor - standingHome.CasAgainst);
                standingGuest.Delta1 = (standingGuest.TdFor - standingGuest.TdAgainst) +
                                       (standingGuest.CasFor - standingGuest.CasAgainst);
                standingHome.Delta2 = (standingHome.TdFor + standingHome.CasFor);
                standingGuest.Delta2 = (standingGuest.TdFor + standingGuest.CasFor);
                if (!standings.Exists(x => x.Team.Id == standingHome.Team.Id)) standings.Add(standingHome);
                if (!standings.Exists(x => x.Team.Id == standingGuest.Team.Id)) standings.Add(standingGuest);
            }
            return standings.OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.Delta1)
                .ThenByDescending(x => x.Delta2)
                .ThenBy(x => x.Team.Name);
        }
    }
}
