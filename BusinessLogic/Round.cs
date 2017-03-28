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

                if (teams.Count % 2 != 0)
                {
                    throw new Exception("Must select an even number of teams!");
                }

                var numTeams = teamIds.Count;
                var numDays = (numTeams - 1);
                var halfSize = numTeams / 2;

                for (var i = 0; i < numDays; i++)
                {
                    rounds.Add(new LegaGladio.Entities.Round());
                }

                var t = new List<LegaGladio.Entities.Team>();

                t.AddRange(teams.Skip(halfSize).Take(halfSize));
                t.AddRange(teams.Skip(1).Take(halfSize - 1).ToArray().Reverse());

                var teamsSize = t.Count;

                for (int day = 0; day < numDays; day++)
                {
                    rounds[day].Name = "Giornata " + day + 1;
                    rounds[day].Number = day;

                    int teamIdx = day % teamsSize;

                    rounds[day].GameList = new List<LegaGladio.Entities.Game>();

                    rounds[day].GameList.Add(new LegaGladio.Entities.Game
                    {
                        Home = t[teamIdx],
                        Guest = teams[0]
                    });

                    for (int idx = 1; idx < halfSize; idx++)
                    {
                        int firstTeam = (day + idx) % teamsSize;
                        int secondTeam = (day + teamsSize - idx) % teamsSize;
                        rounds[day].GameList.Add(new LegaGladio.Entities.Game
                        {
                            Home = t[firstTeam],
                            Guest = t[secondTeam]
                        });
                    }
                }

                foreach (var round in rounds)
                {
                    round.Id = NewRound(round);
                    AddRoundToGroup(round.Id, groupId);
                    foreach (var game in round.GameList)
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
