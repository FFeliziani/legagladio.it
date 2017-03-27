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

        public static void NewRound(LegaGladio.Entities.Round round)
        {
            try
            {
                DataAccessLayer.Round.NewRound(round);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error while creating new Round - Round Data: " + (round != null ? "Round Name: ["  + round.Name + "]" : "ROUND IS NULL!!!"));
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
                var teams = teamIds.Select(Team.GetTeam).ToList();
                var rounds = new List<LegaGladio.Entities.Round>();
                for (var i = 0; i < teams.Count; i++)
                {
                    rounds.Add(new LegaGladio.Entities.Round());
                }

                foreach (var round in rounds)
                {
                    round.GameList = new List<LegaGladio.Entities.Game>();
                    round.Name = "Giornata " + (rounds.IndexOf(round) + 1);
                    round.Number = rounds.IndexOf(round);
                    NewRound(round);
                    var homeTeams = teams.OrderBy(x => Guid.NewGuid()).ToList();
                    var guestTeams = teams.OrderBy(x => Guid.NewGuid()).ToList();
                    foreach (var homeTeam in homeTeams)
                    {
                        foreach (var guestTeam in guestTeams)
                        {
                            if (homeTeam.Equals(guestTeam)) continue;
                            var game = new LegaGladio.Entities.Game
                            {
                                Home = homeTeam,
                                Guest = guestTeam
                            };
                            game.Id = Game.NewGame(game);
                            round.GameList.Add(game);
                            Game.AddGameToRound(game.Id, round.Id);
                        }
                    }
                    AddRoundToGroup(round.Id, groupId);
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
