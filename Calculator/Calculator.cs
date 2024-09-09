namespace Desafio_TDD_xUnit;

public class Calculator(string date)
{
    public readonly string Date = date;
    private readonly Stack<string> _historic = new(); 
    
    public int Add(int a, int b)
    {
        int result = a + b;
        
        AddToHistoric(a, b, result, "+");
        
        return result;   
    }

    public int Subtract(int a, int b)
    {
        int result = a - b;
        
        AddToHistoric(a, b, result, "-");
        
        return result;
    }
    
    public int Multiply(int a, int b) 
    {
        int result = a * b;
        
        AddToHistoric(a, b, result, "*");
        
        return result;
    }
    
    public int Divide(int a, int b)
    {
        int result = a / b;
        
        AddToHistoric(a, b, result, "/");
        
        return result;
    }

    private void AddToHistoric(int a, int b, int result, string operation)
    {
        _historic.Push($"{a} {operation} {b} = {result}");
    }
    
    public List<string> Historic() => _historic.ToList()[..3];
}