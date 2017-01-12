using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegaGladio;

namespace DataAccessLayer
{
    public class Player
    {
        public static int countPlayer()
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            int count = (int)pta.Count();
            pta = null;
            return count;
        }

        public static List<LegaGladio.Entities.Player> listPlayer()
        {
            LegaGladioDS.playerDataTable pdt = new LegaGladioDS.playerDataTable();
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            pta.Fill(pdt);
            List<LegaGladio.Entities.Player> playerList = new List<LegaGladio.Entities.Player>();
            foreach(LegaGladioDS.playerRow playerRow in pdt.Rows)
            {
                LegaGladio.Entities.Player player = new LegaGladio.Entities.Player();
                player.AgMinus = playerRow.agm;
                player.Dead = playerRow.dead;
                player.Retired = playerRow.retired;
                player.AgPlus = playerRow.agp;
                player.AvMinus = playerRow.avm;
                player.AvPlus = playerRow.avp;
                player.Cas = playerRow.cas;
                player.Inter = playerRow.inter;
                player.Cost = playerRow.cost;
                player.Id = playerRow.id;
                player.MaMinus = playerRow.mam;
                player.MaPlus = playerRow.map;
                player.MissNextGame = playerRow.missNextGame;
                player.Name = playerRow.name;
                player.Niggling = playerRow.niggling;
                player.Pass = playerRow.pass;
                player.Spp = playerRow.spp;
                player.StMinus = playerRow.stm;
                player.StPlus = playerRow.stp;
                player.Position = playerRow.position;
                player.Td = playerRow.td;
                player.ListAbility = Skill.listSkill(player.Id);
                player.positional = Positional.getPositional(player);
                playerList.Add(player);
            }
            pta = null;
            pdt = null;
            return playerList;
        }

        public static List<LegaGladio.Entities.Player> listPlayer(int teamID, Boolean active)
        {
            LegaGladioDS.playerDataTable pdt = new LegaGladioDS.playerDataTable();
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            pta.FillByTeamIdActive(pdt, teamID, active);
            List<LegaGladio.Entities.Player> playerList = new List<LegaGladio.Entities.Player>();
            foreach (LegaGladioDS.playerRow playerRow in pdt.Rows)
            {
                LegaGladio.Entities.Player player = new LegaGladio.Entities.Player();
                player.AgMinus = playerRow.agm;
                player.AgPlus = playerRow.agp;
                player.Dead = playerRow.dead;
                player.Retired = playerRow.retired;
                player.AvMinus = playerRow.avm;
                player.AvPlus = playerRow.avp;
                player.Cas = playerRow.cas;
                player.Inter = playerRow.inter;
                player.Cost = playerRow.cost;
                player.Id = playerRow.id;
                player.MaMinus = playerRow.mam;
                player.MaPlus = playerRow.map;
                player.MissNextGame = playerRow.missNextGame;
                player.Name = playerRow.name;
                player.Niggling = playerRow.niggling;
                player.Pass = playerRow.pass;
                player.Spp = playerRow.spp;
                player.StMinus = playerRow.stm;
                player.StPlus = playerRow.stp;
                player.Position = playerRow.position;
                player.Td = playerRow.td;
                player.ListAbility = Skill.listSkill(player.Id);
                player.positional = Positional.getPositional(player);
                playerList.Add(player);
            }
            pta = null;
            pdt = null;
            return playerList;
        }

        public static List<LegaGladio.Entities.Player> listPlayer(int teamID)
        {
            LegaGladioDS.playerDataTable pdt = new LegaGladioDS.playerDataTable();
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            pta.FillByTeamId(pdt, teamID);
            List<LegaGladio.Entities.Player> playerList = new List<LegaGladio.Entities.Player>();
            foreach (LegaGladioDS.playerRow playerRow in pdt.Rows)
            {
                LegaGladio.Entities.Player player = new LegaGladio.Entities.Player();
                player.AgMinus = playerRow.agm;
                player.AgPlus = playerRow.agp;
                player.Dead = playerRow.dead;
                player.Retired = playerRow.retired;
                player.AvMinus = playerRow.avm;
                player.AvPlus = playerRow.avp;
                player.Cas = playerRow.cas;
                player.Inter = playerRow.inter;
                player.Cost = playerRow.cost;
                player.Id = playerRow.id;
                player.MaMinus = playerRow.mam;
                player.MaPlus = playerRow.map;
                player.MissNextGame = playerRow.missNextGame;
                player.Name = playerRow.name;
                player.Niggling = playerRow.niggling;
                player.Pass = playerRow.pass;
                player.Spp = playerRow.spp;
                player.StMinus = playerRow.stm;
                player.StPlus = playerRow.stp;
                player.Position = playerRow.position;
                player.Td = playerRow.td;
                player.ListAbility = Skill.listSkill(player.Id);
                player.positional = Positional.getPositional(player);
                playerList.Add(player);
            }
            pta = null;
            pdt = null;
            return playerList;
        }

        public static LegaGladio.Entities.Player getPlayer(int id)
        {
            LegaGladio.Entities.Player player = null;
            LegaGladioDS.playerDataTable pdt = null;
            LegaGladioDSTableAdapters.playerTableAdapter pta = null;
            LegaGladioDS.playerRow playerRow = null;
            try
            {
                player = new LegaGladio.Entities.Player();
                pdt = new LegaGladioDS.playerDataTable();
                pta = new LegaGladioDSTableAdapters.playerTableAdapter();
                pta.FillById(pdt, id);
                playerRow = (LegaGladioDS.playerRow)pdt.Rows[0];
                player.AgMinus = playerRow.agm;
                player.AgPlus = playerRow.agp;
                player.Dead = playerRow.dead;
                player.Retired = playerRow.retired;
                player.AvMinus = playerRow.avm;
                player.AvPlus = playerRow.avp;
                player.Cas = playerRow.cas;
                player.Inter = playerRow.inter;
                player.Cost = playerRow.cost;
                player.Id = playerRow.id;
                player.MaMinus = playerRow.mam;
                player.MaPlus = playerRow.map;
                player.MissNextGame = playerRow.missNextGame;
                player.Name = playerRow.name;
                player.Niggling = playerRow.niggling;
                player.Pass = playerRow.pass;
                player.Spp = playerRow.spp;
                player.StMinus = playerRow.stm;
                player.StPlus = playerRow.stp;
                player.Position = playerRow.position;
                player.Td = playerRow.td;
                player.ListAbility = Skill.listSkill(player.Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            pta = null;
            pdt = null;
            return player;
        }

        public static void addPlayerToTeam(LegaGladio.Entities.Player player, LegaGladio.Entities.Team team)
        {
            if (player != null && team != null)
            {
                if (!team.ListPlayer.Any(x => x.Id == player.Id))
                {
                    addPlayerToTeam(player.Id, team.Id);
                }
            }
        }

        private static void addPlayerToTeam(Int32 playerId, Int32 teamId)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();

            pta.AddPlayerToTeam(playerId, teamId);
        }

        public static void removePlayerFromTeam(LegaGladio.Entities.Player player, LegaGladio.Entities.Team team)
        {
            if (player != null && team != null)
            {
                if (team.ListPlayer.Any(x => x.Id == player.Id))
                {
                    removePlayerFromTeam(player.Id, team.Id);
                }
            }
        }

        private static void removePlayerFromTeam(Int32 playerId, Int32 teamId)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();

            pta.RemovePlayerFromTeam(playerId, teamId);
        }

        public static Boolean newPlayer(LegaGladio.Entities.Player player)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            //name, map, agp, avp, stp, cost, spp, td, cas, pass, inter, niggling, missNextGame, mam, agm, avm, stm, retired, dead
            int result = pta.Insert(player.Name, player.MaPlus, player.AgPlus, player.AvPlus, player.StPlus, player.Cost, player.Spp, player.Td, player.Cas, player.Pass, player.Inter, player.Niggling, (byte)(player.MissNextGame ? 1 : 0), player.MaMinus, player.AgMinus, player.AvMinus, player.StMinus, (byte)(player.Retired ? 1 : 0), (byte)(player.Dead?1:0), player.positional.Id, player.Position);
            pta = null;
            return result > 0;
        }

        public static void updatePlayer(LegaGladio.Entities.Player player, int oldID)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();

            pta.Update(player.Name, player.MaPlus, player.AgPlus, player.AvPlus, player.StPlus, (decimal)player.Cost, player.Spp, player.Td, player.Cas, player.Pass, player.Inter, player.Niggling, (byte)(player.MissNextGame ? 1 : 0), player.MaMinus, player.AgMinus, player.AvMinus, player.StMinus, (byte)(player.Retired ? 1 : 0), (byte)(player.Dead ? 1 : 0), player.positional.Id, player.Position, oldID);
        }

        public static int calculatePlayerValue(int id)
        {
            int playerValue = 0;

            try
            {
                LegaGladio.Entities.Player player = getPlayer(id);

                playerValue += player.positional.Cost;


                foreach (LegaGladio.Entities.Skill s in player.ListAbility)
                {
                    switch (s.SkillType)
                    {
                        case LegaGladio.Entities.SkillType.AGILITY:
                            playerValue += 20000 + (10000 * player.positional.Agility);
                            break;
                        case LegaGladio.Entities.SkillType.GENERAL:
                            playerValue += 20000 + (10000 * player.positional.General);
                            break;
                        case LegaGladio.Entities.SkillType.PASSING:
                            playerValue += 20000 + (10000 * player.positional.Passing);
                            break;
                        case LegaGladio.Entities.SkillType.STRENGTH:
                            playerValue += 20000 + (10000 * player.positional.Strength);
                            break;
                        case LegaGladio.Entities.SkillType.MUTATION:
                            if (player.positional.Mutation != -1)
                            {
                                playerValue += 20000 + (10000 * player.positional.Mutation);
                            }
                            break;
                    }
                }
                playerValue += 50000 * player.StPlus;
                playerValue += 40000 * player.AgPlus;
                playerValue += 30000 * player.AvPlus;
                playerValue += 30000 * player.MaPlus;
            }
            finally
            {
            }

            return playerValue;
        }

        public static Boolean deletePlayer(int id)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            int result = pta.Delete(id);
            pta = null;
            return result > 0;
        }
    }
}
