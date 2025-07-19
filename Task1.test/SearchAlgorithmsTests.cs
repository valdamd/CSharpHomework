
using Xunit;


namespace Task1.test
{


    public class SearchAlgorithmsTests
    {
       
        private readonly SearchAlgorithms _algorithms;
        
        
        public SearchAlgorithmsTests()
        {
            _algorithms = new SearchAlgorithms();
        }

        [Fact]
        public  void BinarySearch_IntArray_ReturnsCorrectIndex()
        {
            int[] nums = { 1, 3, 5, 7, 9, 11, 13 };
            int target = 7;

            // Act
            int result = _algorithms.Search(nums, target);

            // Assert
            Assert.Equal(3, result);    
        }
        [Fact]
        public void Search_IntArray_ElementNotFound_ReturnsMinusOne()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 7, 9, 11, 13 };
            int target = 6;

            // Act
            int result = _algorithms.Search(nums, target);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Search_IntArray_FirstElement_ReturnsZero()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 7, 9 };
            int target = 1;

            // Act
            int result = _algorithms.Search(nums, target);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Search_IntArray_LastElement_ReturnsLastIndex()
        {
            // Arrange
            int[] nums = { 1, 3, 5, 7, 9 };
            int target = 9;

            // Act
            int result = _algorithms.Search(nums, target);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Search_IntArray_SingleElement_Found_ReturnsZero()
        {
            // Arrange
            int[] nums = {5};
            int target = 5;

            // Act
            int result = _algorithms.Search(nums, target);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Search_IntArray_SingleElement_NotFound_ReturnsMinusOne()
        {
            // Arrange
            int[] nums = { 5 };
            int target = 3;

            // Act
            int result = _algorithms.Search(nums, target);

            // Assert
            Assert.Equal(-1, result);
        }

       

        #region Generic Method Tests - String Array

        [Fact]
        public void BinarySearch_StringArray_ReturnsCorrectIndex()
        {
            // Arrange
            string[] array = { "apple", "banana", "cherry", "date", "grape" };
            string target = "cherry";

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void BinarySearch_StringArray_ElementNotFound_ReturnsMinusOne()
        {
            // Arrange
            string[] array = { "apple", "banana", "cherry", "date", "grape" };
            string target = "orange";

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void BinarySearch_StringArray_FirstElement_ReturnsZero()
        {
            // Arrange
            string[] array = { "apple", "banana", "cherry" };
            string target = "apple";

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(0, result);
        }

        #endregion

        #region Generic Method Tests - Double Array

        [Fact]
        public void BinarySearch_DoubleArray_ReturnsCorrectIndex()
        {
            // Arrange
            double[] array = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double target = 3.3;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void BinarySearch_DoubleArray_ElementNotFound_ReturnsMinusOne()
        {
            // Arrange
            double[] array = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double target = 6.6;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void BinarySearch_DoubleArray_LastElement_ReturnsLastIndex()
        {
            // Arrange
            double[] array = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double target = 5.5;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(4, result);
        }

        #endregion

        #region Boundary Cases

        [Fact]
        public void BinarySearch_EmptyArray_ReturnsMinusOne()
        {
            // Arrange
            int[] array = { };
            int target = 5;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void BinarySearch_NullArray_ReturnsMinusOne()
        {
            // Arrange
            int[]? array = null;
            int target = 5;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void BinarySearch_SingleElement_Found_ReturnsZero()
        {
            // Arrange
            int[] array = { 42 };
            int target = 42;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void BinarySearch_SingleElement_NotFound_ReturnsMinusOne()
        {
            // Arrange
            int[] array = { 42 };
            int target = 10;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void BinarySearch_TwoElements_FirstElement_ReturnsZero()
        {
            // Arrange
            int[] array = { 1, 2 };
            int target = 1;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void BinarySearch_TwoElements_SecondElement_ReturnsOne()
        {
            // Arrange
            int[] array = { 1, 2 };
            int target = 2;

            // Act
            int result = SearchAlgorithms.BinarySearch(array, target);

            // Assert
            Assert.Equal(1, result);
        }

        #endregion
    }
}

