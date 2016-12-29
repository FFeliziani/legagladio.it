using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Action
    {
        public static LegaGladio.Entities.Action getAction(Int32 id)
        {
            LegaGladio.Entities.Action action = null;
            LegaGladioDS.actionDataTable adt = null;
            LegaGladioDSTableAdapters.actionTableAdapter ata = null;
            LegaGladioDS.actionRow ar = null;

            try
            {
                action = new LegaGladio.Entities.Action();
                adt = new LegaGladioDS.actionDataTable();
                adt = new LegaGladioDS.actionDataTable();
                ata.FillById(adt, id);
                if (adt.Rows.Count == 1)
                {
                    ar = (LegaGladioDS.actionRow)adt.Rows[0];
                }
                action.Id = ar.id;
                action.Description = ar.description;
                action.Notes = ar.note;
                action.Spp = ar.spp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ata = null;
                adt = null;
            }
            return action;
        }

        public static List<LegaGladio.Entities.Action> getAction()
        {
            List<LegaGladio.Entities.Action> actions = null;
            LegaGladioDS.actionDataTable adt = null;
            LegaGladioDSTableAdapters.actionTableAdapter ata = null;

            try
            {
                actions = new List<LegaGladio.Entities.Action>();
                ata = new LegaGladioDSTableAdapters.actionTableAdapter();
                adt = new LegaGladioDS.actionDataTable();
                ata.Fill(adt);
                if (adt.Rows.Count > 0)
                {
                    foreach (LegaGladioDS.actionRow ar in adt.Rows)
                    {
                        LegaGladio.Entities.Action action = new LegaGladio.Entities.Action();
                        action.Id = ar.id;
                        action.Description = ar.description;
                        action.Notes = ar.note;
                        action.Spp = ar.spp;
                        actions.Add(action);
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                ata = null;
                adt = null;
            }

            return actions;
        }

        public static void newAction(LegaGladio.Entities.Action action)
        {
            LegaGladioDSTableAdapters.actionTableAdapter ata = new LegaGladioDSTableAdapters.actionTableAdapter();

            ata.Insert(action.Description, action.Spp, action.Notes);
        }
        
        private static void deleteAction(Int32 id)
        {
            LegaGladioDSTableAdapters.actionTableAdapter ata = new LegaGladioDSTableAdapters.actionTableAdapter();

            ata.Delete(id);
        }
    }
}
