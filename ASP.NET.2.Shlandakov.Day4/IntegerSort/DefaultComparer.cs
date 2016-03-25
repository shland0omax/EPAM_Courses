using System.Collections.Generic;

namespace IntegerSort
{
    /// <summary>
    /// Even number are better than odd
    /// </summary>
    public class EvenBetterComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            bool a = x % 2 == 0;
            bool b = y % 2 == 0;
            if ((a && b) || ( !a && !b))
            {
                return x < y ? -1 : x > y ? 1 : 0;
            }
            return a ? 1 : -1;
        }
    }

    /// <summary>
    /// Default integer comparer
    /// </summary>
    public class DefaultIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x < y ? -1 : x > y ? 1 : 0;
        }
    }
}
