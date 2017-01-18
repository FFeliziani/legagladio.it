using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Action
    {
        public static LegaGladio.Entities.Action GetAction(Int32 id)
        {
            var ata = new actionTableAdapter();
            var adt = new LegaGladioDS.actionDataTable();
            ata.FillById(adt, id);
            if (adt.Rows.Count != 1) throw new Exception("Wrong number of action returned!");
            var ar = (LegaGladioDS.actionRow)adt.Rows[0];
            var action = new LegaGladio.Entities.Action
            {
                Id = ar.id,
                Description = ar.description,
                Notes = ar.note,
                Spp = ar.spp
            };
            return action;
        }

        public static IEnumerable<LegaGladio.Entities.Action> ListAction()
        {
            var ata = new actionTableAdapter();
            var adt = new LegaGladioDS.actionDataTable();
            ata.Fill(adt);
            var actions = new List<LegaGladio.Entities.Action>();
            if (adt.Rows.Count > 0)
            {
                actions.AddRange(from LegaGladioDS.actionRow ar in adt.Rows
                    select new LegaGladio.Entities.Action
                    {
                        Id = ar.id, Description = ar.description, Notes = ar.note, Spp = ar.spp
                    });
            }
            return actions;
        }

        public static void NewAction(LegaGladio.Entities.Action action)
        {
            var ata = new actionTableAdapter();

            ata.Insert(action.Description, action.Spp, action.Notes);
        }
        
        private static void DeleteAction(Int32 id)
        {
            var ata = new actionTableAdapter();

            ata.Delete(id);
        }
    }
}
