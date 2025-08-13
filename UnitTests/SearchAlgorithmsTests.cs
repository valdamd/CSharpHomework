// <copyright file="SearchAlgorithmsTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTests;

using FluentAssertions;
using Task1;
using Xunit;

#pragma warning disable IDE1006 //Ошибка в анализаторе

// https://learn.microsoft.com/en-us/visualstudio/code-quality/use-roslyn-analyzers?view=vs-2022
// https://youtrack.jetbrains.com/issue/RSRP-102912/Cannot-resolve-symbol-.ctor
// https://youtrack.jetbrains.com/issue/RSRP-192519/VB-Bad-error-message-Cannot-resolve-symbol-.ctor
// https://github.com/SonarSource/sonar-dotnet
public sealed class SearchAlgorithmsTests
{
    private readonly SearchAlgorithms algorithms = new();

    [Fact]
    public void BinarySearch_IntArray_ReturnsCorrectIndex()
    {
        var nums = new[] { 1, 3, 5, 7, 9, 11, 13 };
        var target = 7;

        var result = this.algorithms.Search(nums, target);
        result.Should().Be(3);
    }

    [Fact]
    public void Search_IntArray_ElementNotFound_ReturnsMinusOne()
    {
        var nums = new[] { 1, 3, 5, 7, 9, 11, 13 };
        var target = 6;
        var result = this.algorithms.Search(nums, target);
        result.Should().Be(-1);
    }

    [Fact]
    public void Search_IntArray_FirstElement_ReturnsZero()
    {
        var nums = new[] { 1, 3, 5, 7, 9 };
        var target = 1;
        var result = this.algorithms.Search(nums, target);
        result.Should().Be(0);
    }

    [Fact]
    public void Search_IntArray_LastElement_ReturnsLastIndex()
    {
        var nums = new[] { 1, 3, 5, 7, 9 };
        var target = 9;
        var result = this.algorithms.Search(nums, target);
        result.Should().Be(4);
    }

    [Fact]
    public void Search_IntArray_SingleElement_Found_ReturnsZero()
    {
        var nums = new[] { 5 };
        var target = 5;
        var result = this.algorithms.Search(nums, target);
        result.Should().Be(0);
    }

    [Fact]
    public void Search_IntArray_SingleElement_NotFound_ReturnsMinusOne()
    {
        var nums = new[] { 5 };
        var target = 3;
        var result = this.algorithms.Search(nums, target);
        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_IntArray_ElementNotFound_ReturnsMinusOne()
    {
        var array = new[] { 1, 3, 5, 7, 9, 11, 13 };
        var target = 6;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_IntArray_FirstElement_ReturnsZero()
    {
        var array = new[] { 1, 3, 5, 7, 9 };
        var target = 1;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(0);
    }

    [Fact]
    public void BinarySearch_IntArray_LastElement_ReturnsLastIndex()
    {
        var array = new[] { 1, 3, 5, 7, 9 };
        var target = 9;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(4);
    }

    [Fact]
    public void BinarySearch_EmptyArray_ReturnsMinusOne()
    {
        var array = Array.Empty<int>();
        var target = 5;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, -1);
        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_NullArray_ReturnsMinusOne()
    {
        int[]? array = (new Random().Next() < 0) ? Array.Empty<int>() : null;
        var target = 5;
        var result = array == null ? -1 : SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_SingleElement_Found_ReturnsZero()
    {
        var array = new[] { 42 };
        var target = 42;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(0);
    }

    [Fact]
    public void BinarySearch_SingleElement_NotFound_ReturnsMinusOne()
    {
        var array = new[] { 42 };
        var target = 10;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearch_TwoElements_FirstElement_ReturnsZero()
    {
        var array = new[] { 1, 2 };
        var target = 1;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(0);
    }

    [Fact]
    public void BinarySearch_TwoElements_SecondElement_ReturnsOne()
    {
        var array = new[] { 1, 2 };
        var target = 2;
        var result = SearchAlgorithms.BinarySearch(array, target, 0, array.Length - 1);
        result.Should().Be(1);
    }
}