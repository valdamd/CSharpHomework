namespace Task1
{
    public sealed class SearchAlgorithms
    {
        public int Search(int[] nums, int target)
        {
            return BinarySearch(nums, target, 0, nums.Length - 1);
        }

        private int BinarySearch(int[] nums, int target, int left, int right)
        {
            if (left > right)
                return -1;

            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[mid] < target)
            {
                return BinarySearch(nums, target, mid + 1, right);
            }

            return BinarySearch(nums, target, left, mid - 1);
        }

        //     public static int BinarySearch<T>(List<T> list, T target) where T : IComparable<T>
        //     {
        //         if (list == null || list.Count == 0) return -1;
        //
        //         var leftIndex = 0;
        //         var rightIndex = list.Count - 1;
        //         while (leftIndex <= rightIndex)
        //         {
        //             int middleIndex = leftIndex + (leftIndex - rightIndex) / 2;
        //             if (target.CompareTo(list[middleIndex]) > 0)
        //             {
        //                 leftIndex = middleIndex + 1;
        //                 continue;
        //             }
        //
        //             if (target.CompareTo(list[middleIndex]) < 0)
        //             {
        //                 rightIndex = middleIndex - 1;
        //                 continue;
        //             }
        //             return middleIndex;
        //         }
        //         return -1;
        //     }
        // }

        public static int BinarySearch1<T>(IReadOnlyList<T> list, T target, Comparison<T>? comparison = null)
        {
            if (list == null || list.Count == 0) return -1;

            // Используем переданный делегат сравнения или стандартный компарер
            var comparer = comparison != null ? Comparer<T>.Create(comparison) : Comparer<T>.Default;

            int leftIndex = 0;
            int rightIndex = list.Count - 1;

            while (leftIndex <= rightIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                // Используем кастомную логику сравнения
                int comparisonResult = comparer.Compare(target, list[middleIndex]);

                if (comparisonResult > 0)
                {
                    leftIndex = middleIndex + 1;
                }
                else if (comparisonResult < 0)
                {
                    rightIndex = middleIndex - 1;
                }
                else
                {
                    return middleIndex; // Элемент найден
                }
            }

            return -1; // Элемент не найден
        }
    }
}