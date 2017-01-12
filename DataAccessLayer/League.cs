using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class League
    {
        public static List<LegaGladio.Entities.League> listLeague()
        {
            LegaGladioDSTableAdapters.leagueTableAdapter lta = null;
            LegaGladioDS.leagueDataTable ldt = null;
            List<LegaGladio.Entities.League> lL = null;

            try
            {
                lta = new LegaGladioDSTableAdapters.leagueTableAdapter();
                ldt = new LegaGladioDS.leagueDataTable();
                lL = new List<LegaGladio.Entities.League>();
                lta.Fill(ldt);

                foreach (LegaGladioDS.leagueRow lr in ldt.Rows)
                {
                    LegaGladio.Entities.League l = new LegaGladio.Entities.League();

                    l.Id = lr.id;
                    l.Name = lr.name;
                    l.Notes = lr.notes;
                    l.Details = lr.details;
                    lL.Add(l);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lta = null;
                ldt = null;
            }
            return lL;
        }

        public static LegaGladio.Entities.League getLeague(Int32 id)
        {
            LegaGladioDSTableAdapters.leagueTableAdapter lta = null;
            LegaGladioDS.leagueDataTable ldt = null;
            LegaGladioDS.leagueRow lr = null;
            LegaGladio.Entities.League l = null;

            try
            {
                lta = new LegaGladioDSTableAdapters.leagueTableAdapter();
                ldt = new LegaGladioDS.leagueDataTable();
                l = new LegaGladio.Entities.League();
                lta.FillById(ldt, id);

                l = new LegaGladio.Entities.League();

                l.Id = lr.id;
                l.Name = lr.name;
                l.Notes = lr.notes;
                l.Details = lr.details;
                l.SeriesList = Series.listSeries(l);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lta = null;
                ldt = null;
            }
            return l;
        }

        public static void newLeague(LegaGladio.Entities.League league)
        {
            LegaGladioDSTableAdapters.leagueTableAdapter lta = new LegaGladioDSTableAdapters.leagueTableAdapter();

            lta.Insert(league.Name, league.Details, league.Notes);
        }

        public static void updateLeague(LegaGladio.Entities.League league, Int32 oldId)
        {
            LegaGladioDSTableAdapters.leagueTableAdapter lta = new LegaGladioDSTableAdapters.leagueTableAdapter();

            lta.Update(league.Name, league.Details, league.Notes, oldId);
        }

        public static void removeLeague(Int32 id)
        {
            LegaGladioDSTableAdapters.leagueTableAdapter lta = new LegaGladioDSTableAdapters.leagueTableAdapter();

            lta.Delete(id);
        }
    }
}
