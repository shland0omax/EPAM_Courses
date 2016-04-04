using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSortLL
{
    /// <summary>
    /// Static class that provides bubble sort for jagged array rows
    /// </summary>
    public static class BubbleSort
    {
        #region Public methods
        /// <summary>
        /// Sorts Jagged array rows using IComparer object
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <param name="comparer">IComparer object</param>
        public static void SortJaggedRows(int[][] array, IComparer<int[]> comparer)
        {
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            SortJaggedRows(array, comparer.Compare);
        }

        /// <summary>
        /// Sorts Jagged array rows
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <param name="comparer">Comparision object which compares array's rows</param>
        public static void SortJaggedRows(int[][] array, Comparison<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + " is null");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer) + " is null");
            }
            for (int i = 0; i < array.Length; i++)
            {
                for( int j = 0; j < array.Length-1-i; j++)
                {
                    if (comparer(array[j], array[j + 1]) > 0)
                    {
                        SwapRows(array, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts Jagged array rows by descending using IComparer object
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <param name="comparer">Comparision object which compares array's rows</param>
        public static void SortJaggedRowsByDesc(int[][] array, IComparer<int[]> comparer)
        {
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));
            SortJaggedRows(array, comparer);
            Reverse(array);
        }

        /// <summary>
        /// Sorts Jagged array rows by descending
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <param name="comparer">Comparision object which compares array's rows</param>
        public static void SortJaggedRowsByDesc(int[][] array, Comparison<int[]> comparer)
        {
            SortJaggedRows(array, comparer);
            Reverse(array);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Metod that helps to swap rows in jagged array
        /// </summary>
        /// <param name="array">Input jagged array</param>
        /// <param name="i">Row number to be swaped</param>
        /// <param name="j">Row number to be swaped</param>
        private static void SwapRows(int[][]array, int i, int j)
        {
            int[] temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /// <summary>
        /// Reverses rows of jagged array
        /// </summary>
        /// <param name="array"></param>
        private static void Reverse(int[][] array)
        {
            int len = array.Length - 1;
            for (int i = 0; i < len; i++, len--)
            {
                SwapRows(array, i, len);
            }
        }
        #endregion
    }
}
