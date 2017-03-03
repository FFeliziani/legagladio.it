using System;

namespace Utilities
{
    public static class RandomUtilities
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
