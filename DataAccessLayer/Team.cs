using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Team
    {
        public static int countTeam()
        {
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();
            int count = (int)tta.Count();
            tta = null;
            return count;
        }

        public static List<LegaGladio.Entities.Team> listTeam()
        {
            LegaGladioDS.teamDataTable tdt = new LegaGladioDS.teamDataTable();
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();
            tta.Fill(tdt);
            List<LegaGladio.Entities.Team> teamList = new List<LegaGladio.Entities.Team>();
            foreach (LegaGladioDS.teamRow tr in tdt.Rows)
            {
                LegaGladio.Entities.Team team = new LegaGladio.Entities.Team();
                team.Id = (int)tr.id;
                team.AssistantCoach = tr.assistantCoach;
                team.Cheerleader = tr.cheerleader;
                //team.coachName = Coach.getCoachName(team.Id);
                //team.ListPlayer = Player.listPlayer(team.Id);
                team.Name = tr.name;
                //team.Race = Race.getRace(team.Id);
                team.Reroll = tr.reroll;
                team.Value = tr.value;
                teamList.Add(team);
            }
            tta = null;
            tdt = null;
            return teamList;
        }

        public static List<LegaGladio.Entities.Team> listTeam(int coachId)
        {
            LegaGladioDS.teamDataTable tdt = new LegaGladioDS.teamDataTable();
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();
            tta.FillByCoachId(tdt, coachId);
            List<LegaGladio.Entities.Team> teamList = new List<LegaGladio.Entities.Team>();
            foreach (LegaGladioDS.teamRow tr in tdt.Rows)
            {
                LegaGladio.Entities.Team team = new LegaGladio.Entities.Team();
                team.Id = (int)tr.id;
                team.AssistantCoach = tr.assistantCoach;
                team.Cheerleader = tr.cheerleader;
                team.coachName = Coach.getCoachName(team.Id);
                team.ListPlayer = Player.listPlayer(team.Id);
                team.Name = tr.name;
                team.Race = Race.getRaceByTeamId(team.Id);
                team.Reroll = tr.reroll;
                team.Value = tr.value;
                teamList.Add(team);
            }
            tta = null;
            tdt = null;
            return teamList;
        }

        public static LegaGladio.Entities.Team getTeam(int id)
        {
            LegaGladio.Entities.Team team = null;
            LegaGladioDS.teamDataTable ttd = null;
            LegaGladioDSTableAdapters.teamTableAdapter tta = null;
            LegaGladioDS.teamRow teamRow = null;
            try
            {
                team = new LegaGladio.Entities.Team();
                ttd = new LegaGladioDS.teamDataTable();
                tta = new LegaGladioDSTableAdapters.teamTableAdapter();
                tta.FillById(ttd, id);
                teamRow = (LegaGladioDS.teamRow)ttd.Rows[0];
                team.Id = (int)teamRow.id;
                team.AssistantCoach = teamRow.assistantCoach;
                team.Cheerleader = teamRow.cheerleader;
                team.coachName = Coach.getCoachName(team.Id);
                team.ListPlayer = Player.listPlayer(team.Id);
                team.Name = teamRow.name;
                team.Race = Race.getRace(team.Id);
                team.Reroll = teamRow.reroll;
                team.Value = teamRow.value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            tta = null;
            ttd = null;
            return team;
        }

        public static Boolean newTeam(LegaGladio.Entities.Team team)
        {
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();
            int result = tta.Insert(team.Value, team.Name, team.FunFactor, team.Reroll, (byte)(team.HasMedic ? 1 : 0), team.Cheerleader, team.AssistantCoach);
            tta = null;
            return result > 0;
        }

        public static Boolean updateTeam(LegaGladio.Entities.Team team, int oldID)
        {
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();
            LegaGladioDS.teamDataTable tdt = new LegaGladioDS.teamDataTable();
            LegaGladioDS.teamRow tr = (LegaGladioDS.teamRow)tdt.NewRow();
            tr.id = (uint)oldID;
            tr.name = team.Name;
            tr.value = team.Value;
            tr.funFactor = team.FunFactor;
            tr.reroll = team.Reroll;
            tr.hasMedic = team.HasMedic;
            tr.cheerleader = team.Cheerleader;
            tr.assistantCoach = team.AssistantCoach;
            int result = tta.Update(tr);
            return result > 0;
        }

        public static Boolean deleteTeam(int id)
        {
            return false;
        }
    }
}
