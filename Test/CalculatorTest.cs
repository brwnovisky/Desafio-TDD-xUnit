using Desafio_TDD_xUnit;

namespace Test;

public class CalculatorTest
{ 
    public Calculator BuildCalculator()
    {
        return new Calculator(DateTime.Now.ToString("dd/MM/yyyy"));
    }
    
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    public void Add(int a, int b, int expected)
    {
        // Arrange
        Calculator calculator = BuildCalculator();
        
        // Act
        int result = calculator.Add(a, b);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(3, 1, 2)]
    [InlineData(9, 4, 5)]
    public void Subtract(int a, int b, int expected)
    {
        // Arrange
        Calculator calculator = BuildCalculator();
        
        // Act
        int result = calculator.Subtract(a, b);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    
    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(4, 5, 20)]
    public void Multiply(int a, int b, int expected)
    {
        // Arrange
        Calculator calculator = BuildCalculator();
        
        // Act
        int result = calculator.Multiply(a, b);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(2, 1, 2)]
    [InlineData(20, 5, 4)]
    public void Divide(int a, int b, int expected)
    {
        // Arrange
        Calculator calculator = BuildCalculator();
        
        // Act
        int result = calculator.Divide(a, b);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void DivideByZero()
    {
        // Arrange
        Calculator calculator = BuildCalculator();
        
        // Act / Assert
        
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(0, 0));
        
    }

    [Fact]
    public void Historic()
    {
        Calculator calculator = BuildCalculator();
        
        calculator.Add(1, 2);
        calculator.Add(3, 4);
        calculator.Add(5, 6);
        calculator.Add(7, 8);
        
        Assert.NotEmpty(calculator.Historic());
        Assert.Equal(3, calculator.Historic().Count);
    }
    
    [Theory]
    [InlineData(1, 2, 3, "+")]
    [InlineData(4, 5, 9, "+")]
    [InlineData(3, 1, 2, "-")]
    [InlineData(9, 4, 5, "-")]
    [InlineData(1, 2, 2, "*")]
    [InlineData(4, 5, 20, "*")]
    [InlineData(2, 1, 2, "/")]
    [InlineData(20, 5, 4, "/")]
    public void ByOperation(int a, int b, int expected, string operation)
    {
        Calculator calculator = BuildCalculator();

        int result = 0;
        
        switch (operation)
        {
            case "+": result = calculator.Add(a, b); break;
            case "-": result = calculator.Subtract(a, b); break;
            case "*": result = calculator.Multiply(a, b); break;
            case "/": result = calculator.Divide(a, b); break;
        }
        
        Assert.Equal(expected, result);
    }
}