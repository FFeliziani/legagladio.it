using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace BusinessLogic
{
    public static class Round
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static LegaGladio.Entities.Round GetRound(Int32 id)
        {
            try
            {
                return DataAccessLayer.Round.GetRound(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while getting round - Id: [" + id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Round> ListRound(LegaGladio.Entities.Group group)
        {
            try
            {
                return DataAccessLayer.Round.ListRound(group);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception while listing rounds for group - Group Id: [" + group.Id + "]");
                throw;
            }
        }

        public static ICollection<LegaGladio.Entities.Round> ListRoundDetailed(LegaGladio.Entities.Group group)
        {
            try
            {
                return DataAccessLayer.Round.ListRoundDetailed(group);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Exception while listing rounds for group - Group Id: [" + group.Id + "]");
                throw;
            }
        }

        public static Int32 NewRound(LegaGladio.Entities.Round round)
        {
            try
            {
                return DataAccessLayer.Round.NewRound(round);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new Round - Round Data: " + (round != null ? "Round Name: [" + round.Name + "]" : "ROUND IS NULL!!!"));
                throw;
            }
        }

        public static void UpdateRound(LegaGladio.Entities.Round round, Int32 oldId)
        {
            try
            {
                DataAccessLayer.Round.UpdateRound(round, oldId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while updating round - Round Data: oldId: [" + oldId + "], " + (round != null ? "Round Name: [" + round.Name + "]" : "ROUND IS NULL!!!"));
                throw;
            }
        }

        public static void AddRoundToGroup(Int32 roundId, Int32 groupId)
        {
            try
            {
                DataAccessLayer.Round.AddRoundToGroup(roundId, groupId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while adding round to group - Round Id: [" + roundId + "], Group Id: [" + groupId + "]");
                throw;
            }
        }

        public static void RemoveRoundFromGroup(Int32 roundId, Int32 groupId)
        {
            try
            {
                DataAccessLayer.Round.RemoveRoundFromGroup(roundId, groupId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while removing round from group - Round Id: [" + roundId + "], Group Id: [" + groupId + "]");
                throw;
            }
        }

        public static void RemoveRound(Int32 id)
        {
            try
            {
                DataAccessLayer.Round.RemoveRound(id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while deleting round - Id: [" + id + "]");
                throw;
            }
        }

        public static void GenerateRounds(Int32 groupId, ICollection<Int32> teamIds)
        {
            try
            {
                var teams = teamIds.Select(Team.GetTeam).OrderBy(x => x.Name).ToList();
                
                var rounds = new List<LegaGladio.Entities.Round>();

                for (var i = 0; i < teams.Count - 1; i++)
                {
                    rounds.Add(new LegaGladio.Entities.Round());
                }

                var gamesDone = new List<LegaGladio.Entities.Game>();
                var repetitions = 0;

                foreach (var round in rounds)
                {
                    var teamsDone = new List<LegaGladio.Entities.Team>();
                    round.Name = "Giornata " + (rounds.IndexOf(round) + 1);
                    round.Number = rounds.IndexOf(round);
                    round.GameList = new List<LegaGladio.Entities.Game>();

                    while (teams.Where(x => !teamsDone.Any(y => x.Id == y.Id)).Count() > 0)
                    {
                        var homeTeam = teams.Where(x => !teamsDone.Any(y => x.Id == y.Id)).FirstOrDefault();
                        teamsDone.Add(homeTeam);
                        var guestTeam = teams.Where(x => !teamsDone.Any(y => x.Id == y.Id)).FirstOrDefault();
                        if (guestTeam == null) throw new Exception("No teams remaining. Please select an even number of teams");
                        teamsDone.Add(guestTeam);
                        var game = new LegaGladio.Entities.Game
                        {
                            Home = homeTeam,
                            Guest = guestTeam
                        };
                        var team = teams.FirstOrDefault();
                        var rot = teams[1];
                        teams.RemoveAt(1);
                        teams.Add(rot);
                        gamesDone.Add(game);
                        round.GameList.Add(game);
                    }
                }

                foreach(var round in rounds)
                {
                    round.Id = NewRound(round);
                    AddRoundToGroup(round.Id, groupId);
                    round.GameList = round.GameList.OrderBy(x => Guid.NewGuid()).ToList();
                    foreach(var game in round.GameList)
                    {
                        game.Id = Game.NewGame(game);
                        Game.AddGameToRound(game.Id, round.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new rounds");
                throw;
            }
        }
    }
}
