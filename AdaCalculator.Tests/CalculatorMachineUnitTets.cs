using Moq;

namespace AdaCalculator.Tests
{
    public class CalculatorMachineUnitTets
    {
        private CalculatorMachine _sut;
        private Mock<ICalculator> calculatorMock;
        private MockRepository mockRepository;
        public CalculatorMachineUnitTets()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            calculatorMock = mockRepository.Create<ICalculator>();
            _sut = new CalculatorMachine(calculatorMock.Object);
        }

        [Fact]
        public void Calculate_WhenSunValidNumbersAndOperation_ShouldTrue()
        {
            calculatorMock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("sum", 17));

            var result = _sut.Calculate("sum", 5, 12);

            Assert.Equal(17, result.result);
            Assert.Equal("sum", result.operation);
        }

        [Fact]
        public void Calculate_WhenSubtraiValidNumbersAndOperation_ShouldTrue()
        {
            calculatorMock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("subtract", 10));

            var result = _sut.Calculate("subtract", 15, 5);

            Assert.Equal(10, result.result);
            Assert.Equal("subtract", result.operation);
        }

        [Fact]
        public void Calculate_WhenDivideValidNumbersAndOperation_ShouldTrue()
        {
            calculatorMock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("divide", 4));

            var result = _sut.Calculate("divide", 20, 5);

            Assert.Equal(4, result.result);
            Assert.Equal("divide", result.operation);
        }

        [Fact]
        public void Calculate_WhenMultiplyValidNumbersAndOperation_ShouldTrue()
        {
            calculatorMock.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("multiply", 10));

            var result = _sut.Calculate("multiply", 2, 5);

            Assert.Equal(10, result.result);
            Assert.Equal("multiply", result.operation);
        }


    }
}