using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaGladio.BusinessLogic
{
    public class Coach
    {
        public static Boolean newCoach(LegaGladio.Entities.Coach coach)
        {
            return DataAccessLayer.Coach.newCoach(coach);
        }
    }
}
