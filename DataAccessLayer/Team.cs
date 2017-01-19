using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Team
    {
        public static int CountTeam()
        {
            var tta = new teamTableAdapter();
            var count = (int)tta.Count();
            return count;
        }

        public static IEnumerable<LegaGladio.Entities.Team> ListTeam()
        {
            var tdt = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.Fill(tdt);
            var teamList = new List<LegaGladio.Entities.Team>();
            foreach (var team in from LegaGladioDS.teamRow tr in tdt.Rows
                                 select new LegaGladio.Entities.Team
                                     {
                                         Id = tr.id,
                                         AssistantCoach = tr.assistantCoach,
                                         Cheerleader = tr.cheerleader,
                                         Name = tr.name,
                                         HasMedic = tr.hasMedic == 1,
                                         FanFactor = tr.funFactor,
                                         Reroll = tr.reroll,
                                         Value = tr.value,
                                         Treasury = tr.treasury,
                                         Active = tr.active == 1
                                     })
            {
                team.Race = Race.GetRaceByTeamId(team.Id);
                team.CoachName = Coach.GetCoachName(team.Id);
                team.CoachId = Coach.GetCoachId(team.Id);
                teamList.Add(team);
            }
            return teamList;
        }

        public static IEnumerable<LegaGladio.Entities.Team> ListTeam(int coachId)
        {
            var tdt = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillByCoachId(tdt, coachId);
            var teamList = new List<LegaGladio.Entities.Team>();
            foreach (var team in from LegaGladioDS.teamRow tr in tdt.Rows
                                 select new LegaGladio.Entities.Team
                                     {
                                         Id = tr.id,
                                         AssistantCoach = tr.assistantCoach,
                                         Cheerleader = tr.cheerleader,
                                         Name = tr.name,
                                         HasMedic = tr.hasMedic == 1,
                                         FanFactor = tr.funFactor,
                                         Reroll = tr.reroll,
                                         Value = tr.value,
                                         Treasury = tr.treasury,
                                         Active = tr.active == 1
                                     })
            {
                team.Race = Race.GetRaceByTeamId(team.Id);
                team.CoachName = Coach.GetCoachName(team.Id);
                team.CoachId = Coach.GetCoachId(team.Id);
                teamList.Add(team);
            }
            return teamList;
        }

        public static IEnumerable<LegaGladio.Entities.Team> ListTeam(Boolean active)
        {
            var tdt = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillByActive(tdt, active ? 1 : 0);
            var teamList = new List<LegaGladio.Entities.Team>();
            foreach (LegaGladioDS.teamRow tr in tdt.Rows)
            {
                try
                {
                    var team = new LegaGladio.Entities.Team
                    {
                        Id = tr.id,
                        AssistantCoach = tr.assistantCoach,
                        Cheerleader = tr.cheerleader,
                        Name = tr.name,
                        HasMedic = tr.hasMedic == 1,
                        FanFactor = tr.funFactor,
                        Reroll = tr.reroll,
                        Value = tr.value,
                        Treasury = tr.treasury,
                        Active = tr.active == 1
                    };
                    team.Race = Race.GetRaceByTeamId(team.Id);
                    team.CoachName = Coach.GetCoachName(team.Id);
                    team.CoachId = Coach.GetCoachId(team.Id);
                    teamList.Add(team);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return teamList;
        }

        public static LegaGladio.Entities.Team GetTeam(int id)
        {
            var ttd = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillById(ttd, id);
            if (ttd.Rows.Count != 1) throw new Exception("Wrong number of rows returned for team");
            var teamRow = ttd.Rows[0] as LegaGladioDS.teamRow;
            if (teamRow == null) return null;
            var team = new LegaGladio.Entities.Team
            {
                Id = teamRow.id,
                AssistantCoach = teamRow.assistantCoach,
                Cheerleader = teamRow.cheerleader,
                HasMedic = teamRow.hasMedic == 1,
                FanFactor = teamRow.funFactor,
                Name = teamRow.name,
                Reroll = teamRow.reroll,
                Treasury = teamRow.treasury,
                Active = teamRow.active == 1
            };
            team.Race = Race.GetRaceByTeamId(team.Id);
            team.CoachName = Coach.GetCoachName(team.Id);
            team.CoachId = Coach.GetCoachId(team.Id);
            team.ListPlayer = Player.ListPlayer(team.Id);
            team.Value = CalculateTeamValue(team.Id);
            return team;
        }

        public static LegaGladio.Entities.Team GetTeamSimple(Int32 id)
        {
            var ttd = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillById(ttd, id);
            if (ttd.Rows.Count != 1) throw new Exception("Wrong number of rows returned for team");
            var teamRow = ttd.Rows[0] as LegaGladioDS.teamRow;
            if (teamRow == null) return null;
            var team = new LegaGladio.Entities.Team
            {
                Id = teamRow.id,
                AssistantCoach = teamRow.assistantCoach,
                Cheerleader = teamRow.cheerleader,
                HasMedic = teamRow.hasMedic == 1,
                FanFactor = teamRow.funFactor,
                Name = teamRow.name,
                Reroll = teamRow.reroll,
                Treasury = teamRow.treasury,
                Active = teamRow.active == 1,
                Value = teamRow.value
            };
            team.Race = Race.GetRaceByTeamId(team.Id);
            team.CoachName = Coach.GetCoachName(team.Id);
            team.CoachId = Coach.GetCoachId(team.Id);
            return team;
        }

        public static LegaGladio.Entities.Team GetTeam(Int32 id, Boolean active)
        {

            var ttd = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillById(ttd, id);
            if (ttd.Rows.Count != 1) throw new Exception("Wrong number of rows returned for team");
            var teamRow = (LegaGladioDS.teamRow)ttd.Rows[0];
            if (teamRow == null) return null;
            var team = new LegaGladio.Entities.Team
            {
                Id = teamRow.id,
                AssistantCoach = teamRow.assistantCoach,
                Cheerleader = teamRow.cheerleader,
                HasMedic = teamRow.hasMedic == 1,
                FanFactor = teamRow.funFactor,
                Name = teamRow.name,
                Reroll = teamRow.reroll,
                Treasury = teamRow.treasury,
                Active = teamRow.active == 1
            };
            team.Race = Race.GetRaceByTeamId(team.Id);
            team.CoachName = Coach.GetCoachName(team.Id);
            team.CoachId = Coach.GetCoachId(team.Id);
            team.ListPlayer = Player.ListPlayer(team.Id, active);
            team.Value = CalculateTeamValue(team.Id);
            return team;
        }

        public static void AddTeamToCoach(LegaGladio.Entities.Team team, LegaGladio.Entities.Coach coach)
        {
            if (team == null || coach == null) return;
            if (coach.ListTeam.All(x => x.Id != team.Id))
            {
                AddTeamToCoach(team.Id, coach.Id);
            }
        }

        private static void AddTeamToCoach(Int32 teamId, Int32 coachId)
        {
            var tta = new teamTableAdapter();

            tta.AddTeamToCoach(teamId, coachId);
        }

        public static void RemoveTeamFromCoach(LegaGladio.Entities.Team team, LegaGladio.Entities.Coach coach)
        {
            if (team == null || coach == null) return;
            if (coach.ListTeam.Any(x => x.Id == team.Id))
            {
                RemoveTeamFromCoach(team.Id, coach.Id);
            }
        }

        private static void RemoveTeamFromCoach(Int32 teamId, Int32 coachId)
        {
            var tta = new teamTableAdapter();

            tta.RemoveTeamFromCoach(teamId, coachId);
        }

        private static int CalculateTeamValue(int id)
        {
            var teamValue = 0;

            
            var ttd = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillById(ttd, id);

            if (ttd.Rows.Count != 1) throw new Exception("Wrong number of teams returned");
            var teamRow = (LegaGladioDS.teamRow)ttd.Rows[0];
            var team = new LegaGladio.Entities.Team
            {
                Id = teamRow.id,
                Reroll = teamRow.reroll,
                AssistantCoach = teamRow.assistantCoach,
                Cheerleader = teamRow.cheerleader,
                FanFactor = teamRow.funFactor
            };
            team.Race = Race.GetRaceByTeamId(team.Id);
            team.ListPlayer = Player.ListPlayer(team.Id, true);
            
            team.HasMedic = teamRow.hasMedic == 1;

            teamValue += team.ListPlayer.Sum(p => Convert.ToInt32(p.Cost));

            teamValue += (10000 * team.AssistantCoach);
            teamValue += (10000 * team.Cheerleader);
            teamValue += (10000 * team.FanFactor);
            teamValue += (team.HasMedic ? 50000 : 0);
            teamValue += (team.Race.Reroll * team.Reroll);

            return teamValue;
        }

        public static void NewTeam(LegaGladio.Entities.Team team)
        {
            var tta = new teamTableAdapter();
            //value, name, funFactor, reroll, hasMedic, cheerleader, assistantCoach, active
            tta.Insert(team.Value, team.Name, team.FanFactor, team.Reroll, (byte)(team.HasMedic ? 1 : 0), team.Cheerleader, team.AssistantCoach, (byte)(team.Active ? 1 : 0), team.Treasury);
        }

        public static void UpdateTeam(LegaGladio.Entities.Team team, int oldId)
        {
            var tta = new teamTableAdapter();

            tta.Update(CalculateTeamValue(oldId), team.Name, team.FanFactor, team.Reroll, (team.HasMedic ? 1 : 0), team.Cheerleader, team.AssistantCoach, (team.Active ? 1 : 0), team.Treasury, oldId);
        }

        /*public static Boolean DeleteTeam(int id)
        {
            return false;
        }*/
    }
}
