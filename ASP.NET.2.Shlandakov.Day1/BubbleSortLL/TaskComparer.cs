using System.Collections.Generic;
using System.Linq;

namespace BubbleSortLL
{
    /// <summary>
    /// Provides basic task methods of int arrays comparision
    /// </summary>
    public static class TaskComparer
    {
        /// <summary>
        /// Compares int arrays according to sum of its elements
        /// </summary>
        /// <param name="la">left array</param>
        /// <param name="ra">right array</param>
        /// <returns>0 - if arrays have the same sum, -1 - if left sum is less, 1 otherwise</returns>
        public static int SumRowCompare(int[] la, int[] ra)
        {
            if (la == ra) return 0;
            if (la == null) return -1;
            if (ra == null) return 1;
            int lSum = la.Sum(), rSum = ra.Sum();
            return lSum < rSum ? -1 : lSum > rSum ? 1 : 0;
        }

        /// <summary>
        /// Compares int arrays according to max of its elements
        /// </summary>
        /// <param name="la">left array</param>
        /// <param name="ra">right array</param>
        /// <returns>0 - if arrays have the same sum, -1 - if left sum is less, 1 otherwise</returns>
        public static int MaxElementCompare(int[] la, int[] ra)
        {
            if (la == ra) return 0;
            if (la == null || la.Length == 0) return -1;
            if (ra == null || ra.Length == 0) return 1;
            int lMax = la.Max(), rMax = ra.Max();
            return lMax < rMax ? -1 : lMax > rMax ? 1 : 0;
        }

        /// <summary>
        /// Compares int arrays according to min of its elements
        /// </summary>
        /// <param name="la">left array</param>
        /// <param name="ra">right array</param>
        /// <returns>0 - if arrays have the same sum, -1 - if left sum is less, 1 otherwise</returns>
        public static int MinElementCompare(int[] la, int[] ra)
        {
            if (la == ra) return 0;
            if (la == null || la.Length == 0) return -1;
            if (ra == null || ra.Length == 0) return 1;
            int lMax = la.Min(), rMax = ra.Min();
            return lMax < rMax ? -1 : lMax > rMax ? 1 : 0;
        }
    }

    /// <summary>
    /// Compares int arrays according to min of its elements
    /// </summary>
    public class MinElementComparer : IComparer<int[]>
    {
        /// <summary>
        /// Compares int arrays according to min of its elements
        /// </summary>
        /// <param name="la">left array</param>
        /// <param name="ra">right array</param>
        /// <returns>0 - if arrays have the same sum, -1 - if left sum is less, 1 otherwise</returns>
        public int Compare(int[] la, int[] ra)
        {
            return TaskComparer.MinElementCompare(la, ra);
        }
    }
}
