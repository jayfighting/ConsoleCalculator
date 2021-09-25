using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace ConsoleCalculator.UnitTests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void CalculatorServiceShouldExecute()
        {
            var mockValidator = new Mock<IValidator>();
            mockValidator.Setup(x => x.Validate(It.IsAny<double[]>(),
                It.IsAny<List<Func<double[], string>>>())).Returns(new ValidateResult());

            var mockParser = new Mock<IParser>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(new double[0]);

            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(x => x.Execute(It.IsAny<double[]>()))
                .Returns(0);

            var sut = new CalculatorService(mockParser.Object, mockValidator.Object, mockCommand.Object);

            sut.Calculate("", new string[0], new List<Func<double[], string>>());

            mockValidator.Verify(x => x.Validate(It.IsAny<double[]>(),
                It.IsAny<List<Func<double[], string>>>()), Times.Once);
            
            mockParser.Verify(x =>  x.Parse(It.IsAny<string>(), It.IsAny<string[]>()), Times.Once);
            
            mockCommand.Verify(x => x.Execute(It.IsAny<double[]>()), Times.Once());
            
        }
    }
}