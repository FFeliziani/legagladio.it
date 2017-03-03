using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.LegaGladioDSTableAdapters;

namespace DataAccessLayer
{
    public static class Injury
    {
        public static LegaGladio.Entities.Injury GetInjury(Int32 id)
        {
            var ita = new injuryTableAdapter();
            var idt = new LegaGladioDS.injuryDataTable();
            ita.FillById(idt, id);
            if (idt.Rows.Count != 1) throw new ArgumentException("Wrong number of injuries returned!");
            var ir = (LegaGladioDS.injuryRow)idt.Rows[0];
            var i = new LegaGladio.Entities.Injury { Id = ir.id, Name = ir.name };
            return i;
        }

        public static ICollection<LegaGladio.Entities.Injury> ListInInjury()
        {
            var ita = new injuryTableAdapter();
            var idt = new LegaGladioDS.injuryDataTable();
            ita.Fill(idt);
            var injuryList = (from LegaGladioDS.injuryRow ir in idt.Rows
                select new LegaGladio.Entities.Injury
                {
                    Id = ir.id,
                    Name = ir.name
                }).ToList();
            return injuryList;
        }

        public static void NewInjury(LegaGladio.Entities.Injury injury)
        {
            var ita = new injuryTableAdapter();

            ita.Insert(injury.Name);
        }

        public static void UpdateInjury(LegaGladio.Entities.Injury injury, Int32 oldId)
        {
            var ita = new injuryTableAdapter();

            ita.Update(injury.Name, oldId);
        }

        public static void DeleteInjury(Int32 id)
        {
            var ita = new injuryTableAdapter();

            ita.Delete(id);
        }
    }
}
