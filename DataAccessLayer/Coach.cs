using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Coach
    {
        public static int countCoach()
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();

            return (int)cta.Count();
        }

        public static List<LegaGladio.Entities.Coach> listCoach()
        {
            return null;
        }

        public static LegaGladio.Entities.Coach getCoach(int id)
        {
            return null;
        }

        public static Boolean newCoach(LegaGladio.Entities.Coach coach)
        {
            LegaGladioDSTableAdapters.coachTableAdapter cta = new LegaGladioDSTableAdapters.coachTableAdapter();

            //name, value, nafID, note, active, nafNick
            cta.Insert(coach.Name, coach.Value, coach.NafID.ToString(), coach.Notes , Convert.ToByte(coach.Active), coach.nafNick);

            return false;
        }

        public static Boolean updateCoach(LegaGladio.Entities.Coach coach, int oldID)
        {
            return false;
        }

        public static Boolean deleteCoach(int id)
        {
            return false;
        }
    }
}
