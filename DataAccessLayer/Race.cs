using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Race
    {
        public static int countRace()
        {
            LegaGladioDSTableAdapters.raceTableAdapter rta = new LegaGladioDSTableAdapters.raceTableAdapter();
            int count = (int)rta.Count();
            rta = null;
            return count;
        }

        public static List<LegaGladio.Entities.Race> listRace()
        {
            LegaGladioDS.raceDataTable rdt = new LegaGladioDS.raceDataTable();
            LegaGladioDSTableAdapters.raceTableAdapter rta = new LegaGladioDSTableAdapters.raceTableAdapter();
            rta.Fill(rdt);
            List<LegaGladio.Entities.Race> raceList = new List<LegaGladio.Entities.Race>();
            foreach (LegaGladioDS.raceRow raceRow in rdt.Rows)
            {
                LegaGladio.Entities.Race race = new LegaGladio.Entities.Race();
                race.Id = (int)raceRow.id;
                race.Name = raceRow.name;
                raceList.Add(race);
            }
            rta = null;
            rdt = null;
            return raceList;
        }

        public static LegaGladio.Entities.Race getRace(int id)
        {
            LegaGladio.Entities.Race race = null;
            LegaGladioDS.raceDataTable rdt = null;
            LegaGladioDSTableAdapters.raceTableAdapter rta = null;
            LegaGladioDS.raceRow raceRow = null;
            try
            {
                rdt = new LegaGladioDS.raceDataTable();
                rta = new LegaGladioDSTableAdapters.raceTableAdapter();
                rta.FillById(rdt, id);
                if (rdt.Rows.Count > 0)
                {
                    race = new LegaGladio.Entities.Race();
                    raceRow = (LegaGladioDS.raceRow)rdt.Rows[0];
                    race.Id = (int)raceRow.id;
                    race.Name = raceRow.name;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            rta = null;
            rdt = null;
            return race;
        }

        public static LegaGladio.Entities.Race getRaceByTeamId(int id)
        {
            LegaGladio.Entities.Race race = null;
            LegaGladioDS.raceDataTable rdt = null;
            LegaGladioDSTableAdapters.raceTableAdapter rta = null;
            LegaGladioDS.raceRow raceRow = null;

            try
            {
                rdt = new LegaGladioDS.raceDataTable();
                rta = new LegaGladioDSTableAdapters.raceTableAdapter();
                rta.FillByTeamId(rdt, id);
                if(rdt.Rows.Count > 0)
                {
                    race = new LegaGladio.Entities.Race();
                    raceRow = (LegaGladioDS.raceRow)rdt.Rows[0];
                    race.Id = (int)raceRow.id;
                    race.Name = raceRow.name;
                }
            }
            catch(Exception ex)
            {
                rdt.GetErrors();
                throw ex;
            }
            finally
            {
                rta = null;
                rdt = null;
            }
            return race;
        }

        public static Boolean newRace(LegaGladio.Entities.Race race)
        {
            LegaGladioDSTableAdapters.raceTableAdapter rta = new LegaGladioDSTableAdapters.raceTableAdapter();
            int result = rta.Insert(race.Name);
            rta = null;
            return result > 0;
        }

        public static Boolean updateRace(LegaGladio.Entities.Race race, int oldID)
        {
            LegaGladioDSTableAdapters.raceTableAdapter rta = new LegaGladioDSTableAdapters.raceTableAdapter();
            LegaGladioDS.raceDataTable rdt = new LegaGladioDS.raceDataTable();
            LegaGladioDS.raceRow rr = (LegaGladioDS.raceRow)rdt.NewRow();
            rr.id = oldID;
            rr.name = race.Name;
            int result = rta.Update(rr);
            return result > 0;
        }

        public static Boolean deleteRace(int id)
        {
            LegaGladioDSTableAdapters.raceTableAdapter rta = new LegaGladioDSTableAdapters.raceTableAdapter();
            int result = rta.Delete(id);
            rta = null;
            return result > 0;
        }
    }
}
