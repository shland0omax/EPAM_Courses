using System;
using System.Collections.Generic;

namespace IntegerSort
{
    /// <summary>
    /// Provides sorting for integer arrays
    /// </summary>
    public static class Sorting
    {
        #region Public Methods
        /// <summary>
        /// Sorts integer array by ascending
        /// </summary>
        /// <param name="array">array to sort</param>
        public static void Sort(int[] array)
        {
            Sort(array, new DefaultIntComparer().Compare);
        }

        /// <summary>
        /// Sorts integer array according to user's comparer
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="comparer">Comparer object</param>
        public static void Sort(int[] array, IComparer<int> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer) + " null comparer object recieved");
            }
            Sort(array, comparer.Compare);
        }

        /// <summary>
        /// Sorts integer array according to user's comparison delegate
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="comparer">Comparison delegate</param>
        public static void Sort(int[] array, Comparison<int> comparer )
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array) + " is null or empty");
            }
            if (array.Length == 1) return;
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer) + " null comparer object recieved");
            }
            MergeSort(array, comparer, 0, array.Length-1);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Recursive part of mergesort
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="comparer">compare delegate</param>
        /// <param name="l">left bound</param>
        /// <param name="r">right bound</param>
        private static void MergeSort(int[] array, Comparison<int> comparer, int l, int r)
        {
            if (l >= r)
                return;
            int mid = (l + r) / 2;
            MergeSort(array, comparer, l, mid);
            MergeSort(array, comparer, mid + 1, r);
            Merge(array, comparer, l, mid, r);
        }

        /// <summary>
        /// Sorting part of mergesort
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="comparer">compare delegate</param>
        /// <param name="l">left bound</param>
        /// <param name="m">median</param>
        /// <param name="r">right bound</param>
        private static void Merge(int[] array, Comparison<int> comparer, int l, int m, int r)
        {
            if (l >= r || m < l || m > r) return;
            if (r == l + 1)
            {
                if (comparer(array[l], array[r]) > 0)
                {
                    int t = array[r];
                    array[r] = array[l];
                    array[l] = t;
                }
            }
            int[] temp = new int[r - l + 1];
            Array.Copy(array, l, temp, 0, r - l + 1);
            for (int i = l, j = 0, k = m - l + 1; i <= r; ++i)
            {
                if (j > m - l)
                    array[i] = temp[k++];
                else if (k > r - l)
                    array[i] = temp[j++];
                else
                    array[i] = comparer(temp[j], temp[k]) < 0 ? temp[j++] : temp[k++];
            }
        }
        #endregion
    }
}
