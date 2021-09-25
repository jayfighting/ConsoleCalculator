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
            mockValidator.Setup(x => x.Validate(It.IsAny<double[]>())).Returns(new ValidateResult());

            var mockParser = new Mock<IParser>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>()))
                .Returns(new double[0]);

            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(x => x.Execute(It.IsAny<double[]>()))
                .Returns(0);

            var sut = new CalculatorService(mockParser.Object, mockValidator.Object, mockCommand.Object);

            sut.Calculate("");

            mockValidator.Verify(x => x.Validate(It.IsAny<double[]>()), Times.Once);
            
            mockParser.Verify(x =>  x.Parse(It.IsAny<string>()), Times.Once);
            
            mockCommand.Verify(x => x.Execute(It.IsAny<double[]>()), Times.Once());
            
        }
    }
}