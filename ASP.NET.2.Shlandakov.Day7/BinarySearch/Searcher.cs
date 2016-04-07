using System;
using System.Collections;
using System.Collections.Generic;

//Как вариант, можно реализовать этот метод как метод расширения.
namespace BinarySearch
{
    /// <summary>
    /// This class provides Binary search for array
    /// </summary>
    public static class Searcher
    {
        /// <summary>
        /// Looks through sorted array for specified element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int BinarySearch<T>( T[] array, T key)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return -1;
            IComparer comparer = Comparer<T>.Default;
            int l = 0, r = array.Length;
            while (l<=r)
            {
                int mid = (l + r)/2;
                int temp = comparer.Compare(key, array[mid]);
                if (temp > 0)
                    l = mid + 1;
                else if (temp < 0)
                    r = mid-1;
                else return mid;
            }
            return -1;
        }
    }
}
