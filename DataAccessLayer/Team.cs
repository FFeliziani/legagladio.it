using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;
using Utilities;

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

        public static ICollection<LegaGladio.Entities.Team> ListTeam()
        {
            var tdt = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.Fill(tdt);
            return (from LegaGladioDS.teamRow tr in tdt.Rows select GetTeamFromRow(tr)).ToList();
        }

        public static ICollection<LegaGladio.Entities.Team> ListTeam(int coachId)
        {
            var tdt = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillByCoachId(tdt, coachId);
            return (from LegaGladioDS.teamRow tr in tdt.Rows select GetTeamFromRow(tr)).ToList();
        }

        public static ICollection<LegaGladio.Entities.Team> ListTeam(Boolean active)
        {
            var tdt = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillByActive(tdt, active ? 1 : 0);
            return (from LegaGladioDS.teamRow tr in tdt.Rows select GetTeamFromRow(tr)).ToList();
        }

        public static LegaGladio.Entities.Team GetTeam(int id)
        {
            var ttd = new LegaGladioDS.teamDataTable();
            var tta = new teamTableAdapter();
            tta.FillById(ttd, id);
            if (ttd.Rows.Count != 1) throw new Exception("Wrong number of rows returned for team");
            var teamRow = ttd.Rows[0] as LegaGladioDS.teamRow;
            if (teamRow == null) return null;
            var team = GetTeamFromRow(teamRow);
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
            var team = GetTeamFromRow(teamRow);
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
            var team = GetTeamFromRow(teamRow);
            team.ListPlayer = Player.ListPlayer(team.Id, active);
            team.ListJourneymen = new List<LegaGladio.Entities.Player>();
            var playerCount = team.ListPlayer.Count(x => !x.MissNextGame);
            if (playerCount + team.ListJourneymen.Count < 11)
            {
                var positionals = Positional.ListPositionalByRace(team.Race.Id);
                var positional = positionals.Aggregate((curMax, x) => ((curMax == null || (x.Qty > curMax.Qty) ? x : curMax)));
                while (playerCount + team.ListJourneymen.Count < 11)
                {
                    var maxPosition = Math.Max(team.ListPlayer.Max(x => x.Position), team.ListJourneymen.Count > 0 ? team.ListJourneymen.Max(x => x.Position) : 0);
                    team.ListJourneymen.Add(new LegaGladio.Entities.Player() { Name = Player.GenerateName(team.Race), Positional = positional, Position = maxPosition + 1, ListAbility = new List<LegaGladio.Entities.Skill>() { Skill.GetSkill("Loner") }, Cost = positional.Cost });
                }
            }
            team.Value = CalculateTeamValue(team.Id);
            return team;
        }

        private static LegaGladio.Entities.Team GetTeamFromRow(LegaGladioDS.teamRow tr)
        {
            var team = new LegaGladio.Entities.Team
            {
                Id = tr.id,
                AssistantCoach = !tr.IsassistantCoachNull() ? tr.assistantCoach : 0,
                Cheerleader = !tr.IscheerleaderNull() ? tr.cheerleader : 0,
                Name = !tr.IsnameNull() ? tr.name : "",
                HasMedic = !tr.IshasMedicNull() && tr.hasMedic == 1,
                FanFactor = !tr.IsfunFactorNull() ? tr.funFactor : 0,
                Reroll = !tr.IsrerollNull() ? tr.reroll : 0,
                Value = !tr.IsvalueNull() ? tr.value : 0,
                Treasury = !tr.IstreasuryNull() ? tr.treasury : 0,
                Active = !tr.IsactiveNull() && tr.active == 1,
                ImagePath = !tr.IsimagePathNull() ? tr.imagePath : Constants.DEFAULT_TEAM_IMAGE
            };
            team.Race = Race.GetRaceByTeamId(team.Id);
            team.CoachName = Coach.GetCoachName(team.Id);
            team.CoachId = Coach.GetCoachId(team.Id);
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
            team.ListJourneymen = new List<LegaGladio.Entities.Player>();
            var playerCount = team.ListPlayer.Count(x => !x.MissNextGame);
            if (playerCount + team.ListJourneymen.Count < 11)
            {
                var positionals = Positional.ListPositionalByRace(team.Race.Id);
                var positional = positionals.Aggregate((curMax, x) => ((curMax == null || (x.Qty > curMax.Qty) ? x : curMax)));
                while (playerCount + team.ListJourneymen.Count < 11)
                {
                    var maxPosition = Math.Max(team.ListPlayer.Max(x => x.Position), team.ListJourneymen.Count > 0 ? team.ListJourneymen.Max(x => x.Position) : 0);
                    team.ListJourneymen.Add(new LegaGladio.Entities.Player() { Name = Player.GenerateName(team.Race), Positional = positional, Position = maxPosition + 1, ListAbility = new List<LegaGladio.Entities.Skill>() { Skill.GetSkill("Loner") }, Cost = positional.Cost });
                }
            }

            team.HasMedic = teamRow.hasMedic == 1;

            teamValue += team.ListPlayer.Sum(p => Convert.ToInt32(p.Cost));
            teamValue += team.ListJourneymen.Sum(p => Convert.ToInt32(p.Cost));

            teamValue += (Constants.ASSISTANT_COACH_VALUE * team.AssistantCoach);
            teamValue += (Constants.CHEERLEADER_VALUE * team.Cheerleader);
            teamValue += (Constants.FAN_FACTOR_VALUE * team.FanFactor);
            teamValue += (team.HasMedic ? Constants.MEDIC_VALUE : 0);
            teamValue += (team.Race.Reroll * team.Reroll);

            return teamValue;
        }

        public static void NewTeam(LegaGladio.Entities.Team team)
        {
            var tta = new teamTableAdapter();
            tta.InsertTeam(team.Value, team.Name, team.FanFactor, team.Reroll, team.Cheerleader, team.AssistantCoach, team.Treasury, team.ImagePath, (Byte)(team.HasMedic ? 1 : 0), (Byte)(team.Active ? 1 : 0));
        }

        public static void UpdateTeam(LegaGladio.Entities.Team team, int oldId)
        {
            var tta = new teamTableAdapter();
            tta.UpdateTeam(CalculateTeamValue(oldId), team.Name, team.FanFactor, team.Reroll, team.Cheerleader,team.AssistantCoach, team.Treasury, team.ImagePath, (Byte)(team.HasMedic ? 1 : 0), (Byte)(team.Active ? 1 : 0), oldId);
        }

        /*public static Boolean DeleteTeam(int id)
        {
            return false;
        }*/
    }
}
