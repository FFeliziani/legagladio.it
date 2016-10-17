using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaGladio.BusinessLogic
{
    public class Positional
    {
        
        public static int count()
        {
            return DataAccessLayer.Positional.countPositional();
        }

        public static List<LegaGladio.Entities.Positional> list()
        {
            return DataAccessLayer.Positional.listPositional();
        }

        public static LegaGladio.Entities.Positional get(int id)
        {
            return DataAccessLayer.Positional.getPositional(id);
        }

        public static Boolean newPositional(LegaGladio.Entities.Positional positional)
        {
            return DataAccessLayer.Positional.newPositional(positional);
        }

        public static Boolean updatePositional(LegaGladio.Entities.Positional positional, int oldID)
        {
            return DataAccessLayer.Positional.updatePositional(positional, oldID);
        }

        public static Boolean deletePositional(int id)
        {
            return DataAccessLayer.Positional.deletePositional(id);
        }
    }
}
