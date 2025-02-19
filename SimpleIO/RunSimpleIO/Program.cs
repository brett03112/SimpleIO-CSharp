using SIO;

public class Example
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer:");
        int intValue = SimpleIO.NextInt();
        Console.WriteLine($"You entered integer: {intValue}");

        Console.WriteLine("Enter a double:");
        double doubleValue = SimpleIO.NextDouble();
        Console.WriteLine($"You entered double: {doubleValue}");

        Console.WriteLine("Enter a string in quotes:");
        string stringValue = SimpleIO.NextString();
        Console.WriteLine($"You entered string: {stringValue}");

        Console.WriteLine("Enter a 1D list of decimals (space-separated, two spaces to end):");
        List<decimal> list1D = SimpleIO.Create1DList();
        Console.WriteLine("1D List:");
        foreach (var num in list1D)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();

        Console.WriteLine("Enter a 2D list of decimals (rows separated by Enter, two Enters to end):");
        List<List<decimal>> list2D = SimpleIO.Create2DList();
        Console.WriteLine("2D List:");
        foreach (var row in list2D)
        {
            foreach (var num in row)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Enter a 3D list of decimals (matrices separated by two Enters, three Enters to end):");
        List<List<List<decimal>>> list3D = SimpleIO.Create3DList();
        Console.WriteLine("3D List:");
        foreach (var matrix in list3D)
        {
            Console.WriteLine("Matrix:");
            foreach (var row in matrix)
            {
                foreach (var num in row)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
