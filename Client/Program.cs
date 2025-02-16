using Client.Library;

while (true)
{
    var operation = SelectOperation(out string firstNumberName, out string secondNumberName, out string operationSymbol);
    var firstNumberValue = InputNumber(firstNumberName);
    var secondNumberValue = InputNumber(secondNumberName);
    var result = Calculate(operation, firstNumberValue, secondNumberValue);

    Screen.Print($"{firstNumberName}:{firstNumberValue:#,#.##} {operationSymbol} {secondNumberName}:{secondNumberValue:#,#.##} = {result:#,#.##}", foreground: ConsoleColor.Green, background: ConsoleColor.Black);
    Console.WriteLine();

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

Operation SelectOperation(out string firstNumberName, out string secondNumberName, out string operationChar)
{
    var options = Enum.GetNames<Operation>();
    int selectedIndex = 0;

    while (true)
    {
        Console.Clear();
        PrintOptions(options, selectedIndex);

        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.UpArrow)
        {
            selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
        }
        else if (key.Key == ConsoleKey.Enter)
        {
            var operation = (Operation)selectedIndex;
            (firstNumberName, secondNumberName, operationChar) = GetNumberNames(operation);
            return operation;
        }
        else if (int.TryParse(key.KeyChar.ToString(), out int selection) && selection > 0 && selection <= options.Length)
        {
            var operation = (Operation)(selection - 1);
            (firstNumberName, secondNumberName, operationChar) = GetNumberNames(operation);
            return operation;
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    static void PrintOptions(string[] options, int selectedIndex)
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Screen.Print($"{i + 1}. {options[i]}\n", foreground: ConsoleColor.Black, background: ConsoleColor.White);
            }
            else
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }
    }
}

(string First, string Second, string Symbol) GetNumberNames(Operation operation)
{
    return operation switch
    {
        Operation.Addition => ("Addend", "Augend", "+"),
        Operation.Subtraction => ("Minuend", "Subtrahend", "-"),
        Operation.Multiplication => ("Multiplicand", "Multiplier", "*"),
        Operation.Division => ("Dividend", "Divisor", "/"),
        Operation.Power => ("Base", "Exponent", "^"),
        Operation.SquareRoot => ("Radicand", "Root", "√"),
        _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
    };
}

static float InputNumber(string numberName)
{
    Console.Write($"Enter the {numberName}: ");
    float numberValue;
    while (!float.TryParse(Console.ReadLine(), out numberValue))
    {
        Console.Write($"Enter the {numberName}: ");
    }

    return numberValue;
}

static float Calculate(Operation operation, float firstNumber, float secondNumber)
{
    var calcLogic = new Client.Library.Calculator();

    return operation switch
    {
        Operation.Addition => calcLogic.Add(firstNumber, secondNumber),
        Operation.Subtraction => calcLogic.Subtract(firstNumber, secondNumber),
        Operation.Multiplication => calcLogic.Multiply(firstNumber, secondNumber),
        Operation.Division => calcLogic.Divide(firstNumber, secondNumber),
        Operation.Power => calcLogic.Power(firstNumber, secondNumber),
        Operation.SquareRoot => calcLogic.SquareRoot(firstNumber),
        _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
    };
}

enum Operation
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Power,
    SquareRoot,
}
