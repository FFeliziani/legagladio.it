using System;
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
            var ir = (LegaGladioDS.injuryRow) idt.Rows[0];
            var i = new LegaGladio.Entities.Injury {Id = ir.id, Name = ir.name};
            return i;
        }
    }
}
