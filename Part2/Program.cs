using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 7, 1, 6, 3, 8, 5, 9, 2, 4 };
            foreach (int i in InsertionSort(arr))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            foreach (int i in InsertionSortRevers(arr))
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Exercise 2.1.3: " + FindValue(arr, 4));
            Console.WriteLine();

            int[] firstBitArr = new int[] { 1, 0, 1, 0, 1, 0 };
            int[] secondBitArr = new int[] { 0, 1, 1, 0, 0, 1 };
            foreach (int i in BitSum(firstBitArr, secondBitArr))
            {
                Console.WriteLine(i);
            }

            foreach (int i in CorrectSelectionSort())
            {
                Console.WriteLine(i);
            }

            int[] mergeArr = new int[] { 1, 2, 3, 4, 5, 1, 3, 5, 7, 8 };
            foreach (int i in Merge(mergeArr, 0, arr.Length / 2, arr.Length))
            {
                Console.WriteLine(i);
            }

            BinarySearch();
        }

        //Insertion-Sort стр 40
        public static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        //Insertion-Sort-Revers стр 40
        public static int[] InsertionSortRevers(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        //2.1.3 стр 45
        public static bool FindValue(int[] arr, int targetNumber)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (targetNumber == arr[i])
                    return true;
            }
            return false;
        }

        //2.1.4 стр 45
        public static int[] BitSum(int[] firstBitArr, int[] secondBitArr)
        {
            int n = 6;
            int[] result = new int[n];
            for(int i = 0; i < n; i++)
            {
                int sum = firstBitArr[i] + secondBitArr[i];
                if(sum == 2)
                    result[i] = 10;
                else
                    result[i] = sum;
            }
            return result;
        }

        //2.2.1 стр 51
        //n^3/1000 - 100n^2 +3 = O(n^3)

        //2.2.2 стр 52
        public static int[] WrongSelectionSort()
        {
            int[] arr = new int[] {9, 1, 8, 4, 6 };
            int notMin = 0;
            int ind = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (min > arr[j])
                    {
                        notMin = min;
                        min = arr[j];
                        ind = j;
                    }
                }
                if (notMin != 0)
                {
                    arr[i] = min;
                    arr[ind] = notMin;
                }
                notMin = 0;
            }
            return arr;
        }
        public static int[] CorrectSelectionSort()
        {
            int[] arr = new int[] { 9, 1, 8, 4, 6 };
            for(int i = 0; i < arr.Length;i++)
            {
                int min = i;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }

        //2.3.1 стр 61
        ///
        /// arr = {3, 41,52,26,38,57,9,49}
        ///                                             |3|9|26|38|41|49|52|57|
        ///                                             /                     \
        ///                                         |3|26|41|52|           |9|38|49|57|
        ///                                         /         \             /         \
        ///                                      |3|41|     |26|52|      |38|57|    |9|49|
        ///                                      /    \      /   \        /    \     /   \
        ///                                     |3|   |41| |52|  |26|   |38|  |57| |9|  |49|
        ///

        //2.3.2 стр 61
        static int[] Merge(int[] arr, int first, int middle, int last)
        {
            int n1 = middle - first + 1;
            int n2 = last - middle;
            int[] firstArr = new int[n1];
            int[] secondArr = new int[n2];
            int[] result = new int[last + 1];
            for(int i = 0; i < n1; i++)
            {
                firstArr[i] = arr[first + i];
            }
            for(int j = 0; j < n2; j++)
            {
                secondArr[j] = arr[middle + j + 1];
            }

            int i2 = 0;
            int j2 = 0;
            for(int k = 0; k <= last; k++)
            {
                if (i2 < n1 && j2 < n2)
                {
                    if (firstArr[i2] <= secondArr[j2])
                    {
                        result[k] = firstArr[i2];
                        i2++;
                    }
                    else
                    {
                        result[k] = secondArr[j2];
                        j2++;
                    }
                    continue;
                }
                if(i2 >= n1 && j2 < n2)
                {
                    result[k] = secondArr[j2];
                    j2++;
                    continue;
                }
                if(i2 < n1 && j2 >= n2)
                {
                    result[k] = firstArr[i2];
                    i2++;
                    continue;
                }
            }
            return result;
        }

        //2.3.5 стр 62
        static bool BinarySearch()
        {
            int val = 7;
            int[] arr = { 1,2,3,4,5,6,7,8,9};
            int firstEl = 0;
            int lastEl = arr.Length;

            while(firstEl <= lastEl)
            {
                int middleEl = (firstEl + lastEl) / 2;

                if (val == arr[middleEl])
                    return true;
                else if(val < arr[middleEl])
                    lastEl = middleEl - 1;
                else
                    firstEl = middleEl + 1; 
            }
            return false;
        }

        //2.3.6 стр 62
        //В задаче говорится о циклей while, если туда добавить бинарный поиск, то производительность не улучшится,
        //т.к. есть внешний цикл for который будет показывать O(n)

        //2.3.7 стр 62
        //???


    }
}
