using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Race
    {
        public static int CountRace()
        {
            var rta = new raceTableAdapter();
            var count = (int)rta.Count();
            return count;
        }

        public static List<LegaGladio.Entities.Race> ListRace()
        {
            var rdt = new LegaGladioDS.raceDataTable();
            var rta = new raceTableAdapter();
            rta.Fill(rdt);
            var raceList = (from LegaGladioDS.raceRow raceRow in rdt.Rows
                select new LegaGladio.Entities.Race
                {
                    Id = raceRow.id, Name = raceRow.name, Reroll = raceRow.reroll
                }).ToList();
            return raceList;
        }

        public static LegaGladio.Entities.Race GetRace(int id)
        {
            
            var rdt = new LegaGladioDS.raceDataTable();
            var rta = new raceTableAdapter();
            rta.FillById(rdt, id);
            if (rdt.Rows.Count <= 0) return null;
            var raceRow = (LegaGladioDS.raceRow)rdt.Rows[0];
            var race = new LegaGladio.Entities.Race {Id = raceRow.id, Name = raceRow.name, Reroll = raceRow.reroll};
            return race;
        }

        public static LegaGladio.Entities.Race GetRaceByTeamId(int id)
        {
            var rdt = new LegaGladioDS.raceDataTable();
            var rta = new raceTableAdapter();
            rta.FillByTeamId(rdt, id);
            if (rdt.Rows.Count <= 0) return null;
            var raceRow = (LegaGladioDS.raceRow)rdt.Rows[0];
            var race = new LegaGladio.Entities.Race {Id = raceRow.id, Name = raceRow.name, Reroll = raceRow.reroll};
            return race;
        }

        public static Boolean NewRace(LegaGladio.Entities.Race race)
        {
            var rta = new raceTableAdapter();
            var result = rta.Insert(race.Name, race.Reroll);
            return result > 0;
        }

        public static Boolean UpdateRace(LegaGladio.Entities.Race race, int oldId)
        {
            var rta = new raceTableAdapter();

            var result = rta.Update(race.Name, race.Reroll, oldId);

            return result > 0;
        }

        public static Boolean DeleteRace(int id)
        {
            var rta = new raceTableAdapter();
            var result = rta.Delete(id);
            return result > 0;
        }
    }
}
