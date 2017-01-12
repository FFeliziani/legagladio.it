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
                team.Id = tr.id;
                team.AssistantCoach = tr.assistantCoach;
                team.Cheerleader = tr.cheerleader;
                team.CoachName = Coach.getCoachName(team.Id);
                team.CoachId = Coach.getCoachId(team.Id);
                //team.ListPlayer = Player.listPlayer(team.Id);
                team.Name = tr.name;
                team.HasMedic = tr.hasMedic;
                team.FanFactor = tr.funFactor;
                team.Race = Race.getRaceByTeamId(team.Id);
                team.Reroll = tr.reroll;
                team.Value = tr.value;
                team.Treasury = tr.treasury;
                team.Active = tr.active;
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
                team.Id = tr.id;
                team.AssistantCoach = tr.assistantCoach;
                team.Cheerleader = tr.cheerleader;
                team.CoachName = Coach.getCoachName(team.Id);
                team.CoachId = Coach.getCoachId(team.Id);
                //team.ListPlayer = Player.listPlayer(team.Id);
                team.Name = tr.name;
                team.HasMedic = tr.hasMedic;
                team.FanFactor = tr.funFactor;
                team.Race = Race.getRaceByTeamId(team.Id);
                team.Reroll = tr.reroll;
                team.Value = tr.value;
                team.Treasury = tr.treasury;
                team.Active = tr.active;
                teamList.Add(team);
            }
            tta = null;
            tdt = null;
            return teamList;
        }

        public static List<LegaGladio.Entities.Team> listTeam(Boolean active)
        {
            LegaGladioDS.teamDataTable tdt = new LegaGladioDS.teamDataTable();
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();
            tta.FillByActive(tdt, active);
            List<LegaGladio.Entities.Team> teamList = new List<LegaGladio.Entities.Team>();
            foreach (LegaGladioDS.teamRow tr in tdt.Rows)
            {
                try
                {
                    LegaGladio.Entities.Team team = new LegaGladio.Entities.Team();
                    team.Id = tr.id;
                    team.AssistantCoach = tr.assistantCoach;
                    team.Cheerleader = tr.cheerleader;
                    team.CoachName = Coach.getCoachName(team.Id);
                    team.CoachId = Coach.getCoachId(team.Id);
                    //team.ListPlayer = Player.listPlayer(team.Id);
                    team.Name = tr.name;
                    team.HasMedic = tr.hasMedic;
                    team.FanFactor = tr.funFactor;
                    team.Race = Race.getRaceByTeamId(team.Id);
                    team.Reroll = tr.reroll;
                    team.Value = tr.value;
                    team.Treasury = tr.treasury;
                    team.Active = tr.active;
                    teamList.Add(team);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
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
                team.Id = teamRow.id;
                team.AssistantCoach = teamRow.assistantCoach;
                team.Cheerleader = teamRow.cheerleader;
                team.CoachName = Coach.getCoachName(team.Id);
                team.CoachId = Coach.getCoachId(team.Id);
                team.ListPlayer = Player.listPlayer(team.Id);
                team.HasMedic = teamRow.hasMedic;
                team.FanFactor = teamRow.funFactor;
                team.Name = teamRow.name;
                team.Race = Race.getRaceByTeamId(team.Id);
                team.Reroll = teamRow.reroll;
                team.Treasury = teamRow.treasury;
                team.Active = teamRow.active;
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

        public static LegaGladio.Entities.Team getTeam(Int32 id, Boolean active)
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
                team.Id = teamRow.id;
                team.AssistantCoach = teamRow.assistantCoach;
                team.Cheerleader = teamRow.cheerleader;
                team.CoachName = Coach.getCoachName(team.Id);
                team.CoachId = Coach.getCoachId(team.Id);
                team.ListPlayer = Player.listPlayer(team.Id, active);
                team.HasMedic = teamRow.hasMedic;
                team.FanFactor = teamRow.funFactor;
                team.Name = teamRow.name;
                team.Race = Race.getRaceByTeamId(team.Id);
                team.Reroll = teamRow.reroll;
                team.Treasury = teamRow.treasury;
                team.Active = teamRow.active;
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

        public static void addTeamToCoach(LegaGladio.Entities.Team team, LegaGladio.Entities.Coach coach)
        {
            if (team != null && team.Id != null && coach != null && coach.Id != null)
            {
                if(!coach.ListTeam.Any(x => x.Id == team.Id))
                {
                    addTeamToCoach(team.Id, coach.Id);
                }
            }
        }

        private static void addTeamToCoach(Int32 teamId, Int32 coachId)
        {
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();

            tta.AddTeamToCoach(teamId, coachId);
        }

        public static void removeTeamFromCoach(LegaGladio.Entities.Team team, LegaGladio.Entities.Coach coach)
        {
            if (team != null && team.Id != null && coach != null && coach.Id != null)
            {
                if (coach.ListTeam.Any(x => x.Id == team.Id))
                {
                    removeTeamFromCoach(team.Id, coach.Id);
                }
            }
        }

        private static void removeTeamFromCoach(Int32 teamId, Int32 coachId)
        {
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();

            tta.RemoveTeamFromCoach(teamId, coachId);
        }

        public static int calculateTeamValue(int id)
        {
            int teamValue = 0;

            try
            {
                LegaGladio.Entities.Team team = getTeam(id);

                foreach (LegaGladio.Entities.Player p in team.ListPlayer)
                {
                    teamValue += Player.calculatePlayerValue(p.Id);
                }

                teamValue += 10000 * team.AssistantCoach;
                teamValue += 10000 * team.Cheerleader;
                teamValue += 10000 * team.FanFactor;
                teamValue += 50000 * (team.HasMedic ? 1 : 0);
                teamValue += team.Race.Reroll * 2 * team.Reroll;
            }
            finally
            {
            }

            return teamValue;
        }

        public static Boolean newTeam(LegaGladio.Entities.Team team)
        {
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();
            //value, name, funFactor, reroll, hasMedic, cheerleader, assistantCoach, active
            int result = tta.Insert(team.Value, team.Name, team.FanFactor, team.Reroll, (byte)(team.HasMedic ? 1 : 0), team.Cheerleader, team.AssistantCoach, (byte)(team.Active? 1 : 0), team.Treasury);
            tta = null;
            return result > 0;
        }

        public static void updateTeam(LegaGladio.Entities.Team team, int oldID)
        {
            LegaGladioDSTableAdapters.teamTableAdapter tta = new LegaGladioDSTableAdapters.teamTableAdapter();

            tta.Update(team.Value, team.Name, team.FanFactor, team.Reroll, (team.HasMedic ? 1 : 0), team.Cheerleader, team.AssistantCoach, (team.Active ? 1 : 0), team.Treasury, oldID);
        }

        public static Boolean deleteTeam(int id)
        {
            return false;
        }
    }
}
