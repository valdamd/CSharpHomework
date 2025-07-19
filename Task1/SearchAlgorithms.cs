namespace Task1
{

    public class SearchAlgorithms
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
                return mid;
            if (nums[mid] < target)
                return BinarySearch(nums, target, mid + 1, right);
        
            return BinarySearch(nums, target, left, mid - 1);
        }

        public static int BinarySearch<T>(T[]? array, T target) where T : IComparable<T>
        {
            if (array == null || array.Length == 0) return -1;

            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            while (leftIndex <= rightIndex)
            {
                int middleIndex = leftIndex + (leftIndex - rightIndex) / 2;
                if (target.CompareTo(array[middleIndex]) > 0)
                {
                    leftIndex = middleIndex + 1;
                    continue;
                }

                if (target.CompareTo(array[middleIndex]) < 0)
                {
                    rightIndex = middleIndex - 1;
                    continue;
                }

                return middleIndex;
            }

            return -1;
        }


    }
}