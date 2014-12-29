namespace IndexVersusPointerInCSharp
{
    public static class ArraySortExtensions
    {
        /// <summary>
        /// Sorts the elements of the sequence in ascending order.
        /// </summary>
        /// <param name="arr">The sequence to in-place sort</param>
        public static void SafeBubbleSort(this int[] arr)
        {
            var flag = true;
            int temp;
            int numLength = arr.Length;

            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts the elements of the sequence in ascending order.
        /// </summary>
        /// <param name="arr">The sequence to in-place sort</param>
        public static unsafe void UnsafeBubbleSort(this int[] arr)
        {
            var flag = true;
            int temp;
            int numLength = arr.Length;

            fixed (int* p = arr)
            {
                for (int* pI = p; (pI <= p + (numLength - 1)) && flag; pI++)
                {
                    flag = false;
                    for (int* pJ = p; pJ < p + (numLength - 1); pJ++)
                    {
                        if (*(pJ + 1) < *pJ)
                        {
                            temp = *pJ;
                            *pJ = *(pJ + 1);
                            *(pJ + 1) = temp;
                            flag = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a sequence is in ascending order
        /// </summary>
        /// <param name="arr">The sequence to check</param>
        /// <returns>Returns True when the sequence is in ascending order, otherwise, returns False</returns>
        public static bool CheckAscendingSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    return false;

            return true;
        }
    }
}
