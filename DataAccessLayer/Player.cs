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

        public static Boolean newPlayer(LegaGladio.Entities.Player player)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            //name, map, agp, avp, stp, cost, spp, td, cas, pass, inter, niggling, missNextGame, mam, agm, avm, stm, retired, dead
            int result = pta.Insert(player.Name, player.MaPlus, player.AgPlus, player.AvPlus, player.StPlus, player.Cost, player.Spp, player.Td, player.Cas, player.Pass, player.Inter, player.Niggling, (byte)(player.MissNextGame ? 1 : 0), player.MaMinus, player.AgMinus, player.AvMinus, player.StMinus, (byte)(player.Retired ? 1 : 0), (byte)(player.Dead?1:0), player.positional.Id);
            pta = null;
            return result > 0;
        }

        public static Boolean updatePlayer(LegaGladio.Entities.Player player, int oldID)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            LegaGladioDS.playerDataTable pdt = new LegaGladioDS.playerDataTable();
            LegaGladioDS.playerRow pr = (LegaGladioDS.playerRow)pdt.NewRow();
            pr.agm = player.AgMinus;
            pr.agp = player.AgPlus;
            pr.dead = player.Dead;
            pr.retired = player.Retired;
            pr.avm = player.AvMinus;
            pr.avp = player.AvPlus;
            pr.cas = player.Cas;
            pr.inter = player.Inter;
            pr.cost = player.Cost;
            pr.id = oldID;
            pr.mam = player.MaMinus;
            pr.map = player.MaPlus;
            pr.missNextGame = player.MissNextGame;
            pr.name = player.Name;
            pr.niggling = player.Niggling;
            pr.pass = player.Pass;
            pr.spp = player.Spp;
            pr.stm = player.StMinus;
            pr.stp = player.StPlus;
            pr.td = player.Td;
            int result = pta.Update(pr);
            return result > 0;
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
