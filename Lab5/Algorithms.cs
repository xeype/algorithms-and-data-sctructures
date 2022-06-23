using System;

namespace Lab5
{
    public class Algorithms
    {
        private int GetMax(int[] arr, int n)
        {
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            return max;
        }

        private int[] CountSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int i;
            int[] count = new int[10];

            for (i = 0; i < 10; i++)
                count[i] = 0;

            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (i = 0; i < n; i++)
                arr[i] = output[i];

            return arr;
        }

        public int[] RadixSort(int[] arr)
        {
            int length = arr.Length;
            int max = GetMax(arr, length);

            for (int exp = 1; max / exp > 0; exp *= 10)
                arr = CountSort(arr, length, exp);

            return arr;
        }

        public int LinearSearch(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        public int BinarySearch(int[] arr, int target)
        {
            arr = RadixSort(arr);
            int left = 0;
            int right = arr.Length - 1;
            int res = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                    return mid;
                if (arr[mid] < target)
                {
                    left = mid + 1;
                    res = mid + 1;
                }
                else
                {
                    res = mid;
                    right = mid - 1;
                }
            }

            return res;
        }

        public int BreakSearch(int[] arr, int key)
        {
            int index = 0;
            int length = arr.Length;
            if (arr[length - 1] != key)
            {
                arr[length - 1] = key;
                for (; arr[index] != key; index++) ;
                index++;
            }
            else return length;

            return index < length ? index : -1;
        }

        public void KMPSearch(string patt, string txt)
        {
            int m = patt.Length;
            int n = txt.Length;

            int[] longPrefSuf = new int[m];
            int j = 0;

            CalculateLongPrefSuf(patt, m, longPrefSuf);

            int i = 0;
            while (i < n)
            {
                if (patt[j] == txt[i])
                {
                    j++;
                    i++;
                }

                if (j == m)
                {
                    Console.Write("Pattern found "
                                  + "at index " + (i - j));
                    j = longPrefSuf[j - 1];
                }

                else if (i < n && patt[j] != txt[i])
                {
                    if (j != 0)
                        j = longPrefSuf[j - 1];
                    else
                        i = i + 1;
                }
            }
        }

        private void CalculateLongPrefSuf(string patt, int m, int[] longPrefSuf)
        {
            int len = 0;
            int i = 1;
            longPrefSuf[0] = 0;

            while (i < m)
            {
                if (patt[i] == patt[len])
                {
                    len++;
                    longPrefSuf[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                        len = longPrefSuf[len - 1];
                    else
                    {
                        longPrefSuf[i] = len;
                        i++;
                    }
                }
            }
        }
    }
}