using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubbleSortLL;
using System.Diagnostics;

namespace TestSortPL
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 1, 3, 5, 6, 3 };
            array[1] = new int[] { 5, 2, 3, 4 };
            array[2] = new int[] { };
            array[3] = new int[] { 2, -6,5,3,5,3 };
            array[4] = new int[] { -3, -5, 3, 4, 0 };
            try
            {
                BubbleSort.SortJaggedRows(array, SortMode.RowSum, SortOrder.Desc);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error occured:" + e.Message);
                return;
            }
            foreach (int[] row in array)
            {
                foreach(int elem in row)
                {
                    Console.Write("{0}, ", elem);
                }
                Console.WriteLine();
            }
        }
    }
}
