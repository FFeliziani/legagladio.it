using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Positional
    {
        public static int countPositional()
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();
            return (int)pta.Count();
        }

        public static List<LegaGladio.Entities.Positional> listPositional()
        {
            return null;
        }

        public static LegaGladio.Entities.Positional getPositional(int id)
        {
            return null;
        }
        public static Boolean newPositional(LegaGladio.Entities.Positional positional)
        {
            LegaGladioDSTableAdapters.positionalTableAdapter pta = new LegaGladioDSTableAdapters.positionalTableAdapter();

            //g, a, s, p, m, e
            int id = pta.Insert(positional.Qty, positional.Title, positional.Cost, positional.Ma, positional.St, positional.Ag, positional.Av, (int)positional.General, (int)positional.Agility, (int)positional.Strength, (int)positional.Passing, (int)positional.Mutation, (int)positional.Extraordinary);
            return id > -1;
        }

        public static Boolean updatePositional(LegaGladio.Entities.Positional positional, int oldID)
        {
            return false;
        }

        public static Boolean deletePositional(int id)
        {
            return false;
        }


    }
}
