using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class RandomUtilities
    {
        public static Random Random { get; private set; }

        public static void Init(Int32 seed = 0)
        {
            if (Random == null)
            {
                Random = seed > 0 ? new Random(seed) : new Random(new DateTime().Millisecond);
            }
        }
    }
}
