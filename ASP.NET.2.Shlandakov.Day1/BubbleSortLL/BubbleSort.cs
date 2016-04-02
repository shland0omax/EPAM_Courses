using System;

namespace BubbleSortLL
{
    /// <summary>
    /// Static class that provides bubble sort for jagged array rows
    /// </summary>
    public static class BubbleSort
    {
        #region Public methods
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
                throw new ArgumentException(nameof(comparer) + " is null");
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
        #endregion
    }
}
