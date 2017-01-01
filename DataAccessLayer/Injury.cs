using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    class Injury
    {
        public static LegaGladio.Entities.Injury getInjury(Int32 id)
        {
            LegaGladioDSTableAdapters.injuryTableAdapter ita = null;
            LegaGladioDS.injuryDataTable idt = null;
            LegaGladio.Entities.Injury i = null;
            LegaGladioDS.injuryRow ir = null;

            try
            {
                ita = new LegaGladioDSTableAdapters.injuryTableAdapter();
                idt = new LegaGladioDS.injuryDataTable();
                ita.FillById(idt, id);
                if (idt.Rows.Count != 1)
                {
                    throw new ArgumentException("Wrong number of injuries returned!");
                }
                ir = (LegaGladioDS.injuryRow)idt.Rows[0];
                i.Id = ir.id;
                i.Name = ir.name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ita = null;
                idt = null;
            }
            return i;
        }
    }
}
