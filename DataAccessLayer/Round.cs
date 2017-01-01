using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Round
    {
        public static LegaGladio.Entities.Round getRound(Int32 id)
        {
            LegaGladioDSTableAdapters.roundTableAdapter rta = null;
            LegaGladioDS.roundDataTable rdt = null;
            LegaGladio.Entities.Round r = null;

            try
            {
                rta = new LegaGladioDSTableAdapters.roundTableAdapter();
                rdt = new LegaGladioDS.roundDataTable();
                rta.FillById(rdt, id);
                if (rdt.Rows.Count != 1)
                {
                    throw new ArgumentException("Wrong number of rounds returned!");
                }
                LegaGladioDS.roundRow rr = (LegaGladioDS.roundRow)rdt.Rows[0];
                r = new LegaGladio.Entities.Round();
                r.Id = rr.id;
                r.Name = rr.name;
                r.Number = rr.number;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                rta = null;
                rdt = null;
            }

            return r;
        }

    }
}
