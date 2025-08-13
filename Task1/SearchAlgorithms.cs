// <copyright file="SearchAlgorithms.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task1;

internal sealed record SearchAlgorithms
{
    public int Search(int[]? array, int target)
    {
        if (array == null || array.Length == 0)
        {
            return -1;
        }

        return BinarySearch(array, target, 0, array.Length - 1);
    }

    public static int BinarySearch(int[] nums, int target, int left, int right)
    {
        if (left > right || left < 0 || right >= nums.Length)
        {
            return -1;
        }

        var mid = left + ((right - left) / 2);
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

    public static int BinarySearch1<T>(IReadOnlyList<T> list, T target, Comparison<T>? comparison = null)
    {
        if (list.Count == 0)
        {
            return -1;
        }

        var comparer = comparison != null ? Comparer<T>.Create(comparison) : Comparer<T>.Default;

        var leftIndex = 0;
        var rightIndex = list.Count - 1;

        while (leftIndex <= rightIndex)
        {
            var middleIndex = leftIndex + ((rightIndex - leftIndex) / 2);
            var comparisonResult = comparer.Compare(target, list[middleIndex]);

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
                return middleIndex;
            }
        }

        return -1;
    }
}
