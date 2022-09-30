using System;

namespace AdaCalculator.Tests
{
    public class CalculatorUnitTests
    {
        private readonly Calculator _sut;
        public CalculatorUnitTests()
        {
            _sut = new Calculator();
        }
        [Theory]
        [InlineData("sum", 4, 5, 9)]
        [InlineData("sum", 5.4, 6.6, 12)]
        [InlineData("sum", 12, 7, 19)]
        [InlineData("sum", 12, 0, 12)]
        public void Calculate_SumValidOperation_ShouldReturnTrue(string operation, double a, double b, double expected)
        {
            var result = _sut.Calculate(operation, a, b);
            Assert.Equal("sum", result.operation);
            Assert.Equal(expected, result.result);
        }

        [Theory]
        [InlineData("subtract", 4, 5, -1)]
        [InlineData("subtract", -5.4, 6.6, -12)]
        [InlineData("subtract", 12, 7, 5)]
        [InlineData("subtract", 12, 0, 12)]
        public void Calculate_SubtractValidOperation_ShouldReturnTrue(string operation, double a, double b, double expected)
        {
            var result = _sut.Calculate(operation, a, b);
            Assert.Equal("subtract", result.operation);
            Assert.Equal(expected, result.result);
        }


        [Theory]
        [InlineData("multiply", -4, 5, -20)]
        [InlineData("multiply", 54, 66, 3564)]
        [InlineData("multiply", -12, -7, 84)]
        [InlineData("multiply", -12, 0, 0)]
        public void Calculate_MultiplyValidOperation_ShouldReturnTrue(string operation, double a, double b, double expected)
        {
            var result = _sut.Calculate(operation, a, b);
            Assert.Equal("multiply", result.operation);
            Assert.Equal(expected, result.result);
        }


        [Theory]
        [InlineData("divide", -4, 5, -0.80)]
        [InlineData("divide", 90, 18, 5)]
        [InlineData("divide", -12, -7, 1.71)]
        [InlineData("divide", 0, -7, 0)]
        public void Calculate_DivideValidOperation_ShouldReturnTrue(string operation, double a, double b, double expected)
        {
            var result = _sut.Calculate(operation, a, b);
            Assert.Equal("divide", result.operation);
            Assert.Equal(expected, result.result);
        }


        [Theory]
        [InlineData("operação", -4, 5)]
        [InlineData("multiplai", 54, 66)]
        [InlineData("diviide", 90, 18)]
        [InlineData("sun", 12, 7)]
        public void Calculate_InvalidOperation_ShouldThrowArgumentException(string operation, double a, double b)
        {
            Action result = () => _sut.Calculate(operation, a, b);
            Assert.Throws<ArgumentException>(result);
        }

        [Theory]
        [InlineData("divide", -4, 0)]
        [InlineData("divide", 54, 0)]
        [InlineData("divide", 9.0, 0)]
        public void Calculate_DivideByZero_ShouldThrowDivideByZeroException(string operation, double a, double b)
        {
            Action result = () => _sut.Calculate(operation, a, b);
            Assert.Throws<DivideByZeroException>(result);
        }

    }
}