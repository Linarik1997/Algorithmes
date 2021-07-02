using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2
{
    class BinarySearch
    {
        public static int ArrayBinarySearch(int[] arr, int searchValue)
        {
            if (IsSorted(arr))
            {
                return SearchBin(arr, searchValue);
            }
            else
            {
                BubleSort(arr);
                return SearchBin(arr, searchValue);
            }
        }
        private static int SearchBin(int[] arr, int searchValue)
        {
            int min = 0;
            int max = arr.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == arr[mid])
                    return mid;
                else if(searchValue < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        private static bool IsSorted(int[] arr)
        {
            var count = arr.Length;
            for(int i = 0; i < count-1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }
        private static void BubleSort(int[] arr)
        {
            var count = arr.Length;
            for(int i = 0; i < count; i++)
            {
                for(int j =0; j<count - 1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
