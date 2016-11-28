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
                player.Ag = playerRow.ag;
                player.Av = playerRow.av;
                player.Cas = playerRow.cas;
                player.Cat = playerRow.cat;
                player.Cost = playerRow.cost;
                player.Id = (int)playerRow.id;
                player.Ma = playerRow.ma;
                player.MissNextGame = playerRow.missNextGame;
                player.Name = playerRow.name;
                player.Niggling = playerRow.niggling;
                player.Pass = playerRow.pass;
                player.Spp = playerRow.spp;
                player.St = playerRow.st;
                player.Td = playerRow.td;
                player.ListAbility = Skill.listSkill(player.Id);
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
                player.Ag = playerRow.ag;
                player.Av = playerRow.av;
                player.Cas = playerRow.cas;
                player.Cat = playerRow.cat;
                player.Cost = playerRow.cost;
                player.Id = (int)playerRow.id;
                player.Ma = playerRow.ma;
                player.MissNextGame = playerRow.missNextGame;
                player.Name = playerRow.name;
                player.Niggling = playerRow.niggling;
                player.Pass = playerRow.pass;
                player.Spp = playerRow.spp;
                player.St = playerRow.st;
                player.Td = playerRow.td;
                player.ListAbility = Skill.listSkill(player.Id);
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
                player.Ag = playerRow.ag;
                player.Av = playerRow.av;
                player.Cas = playerRow.cas;
                player.Cat = playerRow.cat;
                player.Cost = playerRow.cost;
                player.Id = (int)playerRow.id;
                player.Ma = playerRow.ma;
                player.MissNextGame = playerRow.missNextGame;
                player.Name = playerRow.name;
                player.Niggling = playerRow.niggling;
                player.Pass = playerRow.pass;
                player.Spp = playerRow.spp;
                player.St = playerRow.st;
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
            int result = pta.Insert(player.Name, player.Ma, player.Ag, player.Av, player.St, player.Cost, player.Spp, player.Td, player.Cas, player.Pass, player.Cat, player.Niggling, (byte)(player.MissNextGame?1:0));
            pta = null;
            return result > 0;
        }

        public static Boolean updatePlayer(LegaGladio.Entities.Player player, int oldID)
        {
            LegaGladioDSTableAdapters.playerTableAdapter pta = new LegaGladioDSTableAdapters.playerTableAdapter();
            LegaGladioDS.playerDataTable pdt = new LegaGladioDS.playerDataTable();
            LegaGladioDS.playerRow pr = (LegaGladioDS.playerRow)pdt.NewRow();
            pr.ag = player.Ag;
            pr.av = player.Av;
            pr.cas = player.Cas;
            pr.cat = player.Cat;
            pr.cost = player.Cost;
            pr.id = oldID;
            pr.ma = player.Ma;
            pr.missNextGame = player.MissNextGame;
            pr.name = player.Name;
            pr.niggling = player.Niggling;
            pr.pass = player.Pass;
            pr.spp = player.Spp;
            pr.st = player.St;
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
