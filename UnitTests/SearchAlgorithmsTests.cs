using FluentAssertions;
using Task1;
using Xunit;

namespace UnitTests;

#pragma warning disable IDE1006

public sealed class SearchAlgorithmsTests
{
    private readonly SearchAlgorithms _algorithms = new();

    [Fact]
    public void Search_IntArray_ReturnsCorrectIndex()
    {
        var nums = new[] { 1, 3, 5, 7, 9, 11, 13 };
        var target = 7;

        var result = _algorithms.Search(nums, target);

        result.Should().Be(3);
    }

    [Fact]
    public void Search_IntArray_ElementNotFound_ReturnsMinusOne()
    {
        var nums = new[] { 1, 3, 5, 7, 9, 11, 13 };
        var target = 6;

        var result = _algorithms.Search(nums, target);

        result.Should().Be(-1);
    }

    [Fact]
    public void Search_NullArray_ReturnsMinusOne()
    {
        int[]? array = null;
        var target = 5;

        var result = _algorithms.Search(array, target);

        result.Should().Be(-1);
    }

    [Fact]
    public void Search_EmptyArray_ReturnsMinusOne()
    {
        var array = Array.Empty<int>();
        var target = 5;

        var result = _algorithms.Search(array, target);

        result.Should().Be(-1);
    }

    [Fact]
    public void Search_SingleElement_Found_ReturnsZero()
    {
        var nums = new[] { 5 };
        var target = 5;

        var result = _algorithms.Search(nums, target);

        result.Should().Be(0);
    }

    [Fact]
    public void Search_SingleElement_NotFound_ReturnsMinusOne()
    {
        var nums = new[] { 5 };
        var target = 3;

        var result = _algorithms.Search(nums, target);

        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_NullArray_ShouldThrowArgumentNullException()
    {
        int[]? array = null;
        var target = 5;

        Action act = () => SearchAlgorithms.BinarySearch(array!, target, 0, 0);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void BinarySearch_InvalidIndices_LeftGreaterThanRight_ReturnsMinusOne()
    {
        var array = new[] { 1, 2, 3, 4, 5 };
        var target = 3;

        var result = SearchAlgorithms.BinarySearch(array, target, 3, 1);

        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_InvalidIndices_NegativeLeft_ReturnsMinusOne()
    {
        var array = new[] { 1, 2, 3, 4, 5 };
        var target = 3;

        var result = SearchAlgorithms.BinarySearch(array, target, -1, 4);

        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_InvalidIndices_RightOutOfBounds_ReturnsMinusOne()
    {
        var array = new[] { 1, 2, 3, 4, 5 };
        var target = 3;

        var result = SearchAlgorithms.BinarySearch(array, target, 0, 10);

        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_Subarray_FindsElementInRange()
    {
        var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var target = 5;

        var result = SearchAlgorithms.BinarySearch(array, target, 2, 6);

        result.Should().Be(4);
    }

    [Fact]
    public void BinarySearch_Subarray_ElementOutsideRange_ReturnsMinusOne()
    {
        var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var target = 8;

        var result = SearchAlgorithms.BinarySearch(array, target, 0, 4);

        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_SingleElementRange_Found_ReturnsIndex()
    {
        var array = new[] { 1, 2, 3, 4, 5 };
        var target = 3;

        var result = SearchAlgorithms.BinarySearch(array, target, 2, 2);

        result.Should().Be(2);
    }

    [Fact]
    public void BinarySearch_SingleElementRange_NotFound_ReturnsMinusOne()
    {
        var array = new[] { 1, 2, 3, 4, 5 };
        var target = 4;

        var result = SearchAlgorithms.BinarySearch(array, target, 2, 2);

        result.Should().Be(-1);
    }

    [Fact]
    public void Search_LargeArray_FindsMiddleElement()
    {
        var nums = Enumerable.Range(1, 1000).ToArray();
        var target = 500;

        var result = _algorithms.Search(nums, target);

        result.Should().Be(499);
    }

    [Fact]
    public void Search_ArrayWithDuplicates_FindsFirstOccurrence()
    {
        var nums = new[] { 1, 2, 2, 2, 3, 4, 5 };
        var target = 2;

        var result = _algorithms.Search(nums, target);

        result.Should().BeOneOf(1, 2, 3);
    }

    [Fact]
    public void BinarySearch_NegativeNumbers_WorksCorrectly()
    {
        var array = new[] { -10, -5, -1, 0, 1, 5, 10 };
        var target = -5;

        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);

        result.Should().Be(1);
    }

    [Fact]
    public void BinarySearch_ZeroTarget_WorksCorrectly()
    {
        var array = new[] { -5, -1, 0, 1, 5 };
        var target = 0;

        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);

        result.Should().Be(2);
    }

    [Theory]
    [InlineData(new[] { 1 }, 1, 0)]
    [InlineData(new[] { 1, 3 }, 1, 0)]
    [InlineData(new[] { 1, 3 }, 3, 1)]
    [InlineData(new[] { 1, 3, 5 }, 3, 1)]
    [InlineData(new[] { 1, 3, 5, 7 }, 7, 3)]
    public void Search_VariousArraySizes_FindsElements(int[] array, int target, int expectedIndex)
    {
        var result = _algorithms.Search(array, target);

        result.Should().Be(expectedIndex);
    }
}