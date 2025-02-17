# SimpleIO - C# Input Utility Class

## Overview

`SimpleIO` is a static C# class designed to simplify reading and parsing input from the console. It provides a set of convenient methods to read tokens, numbers, strings, and create lists and multi-dimensional lists directly from console input. This class is particularly useful for competitive programming, quick scripting, or any scenario where you need to efficiently handle console input in C#.

## Features

The `SimpleIO` class offers the following static methods:

* **`NextToken()`**:
    Reads a token (a sequence of non-whitespace characters) from the console input. Skips any leading and trailing whitespace characters.

* **`NextInt()`**:
    Reads an integer from the console input. Skips leading and trailing whitespace and parses the token as an integer.

* **`NextDouble(bool acceptAnyDecimalSeparator = true)`**:
    Reads a double-precision floating-point number from the console input. Skips leading and trailing whitespace.
  * `acceptAnyDecimalSeparator`:  A boolean parameter that, when set to `true` (default), allows both '.' (dot) and ',' (comma) to be recognized as decimal separators. If `false`, only the system's default decimal separator is accepted.

* **`NextDecimal(bool acceptAnyDecimalSeparator = true)`**:
    Reads a decimal number from the console input. Skips leading and trailing whitespace.
  * `acceptAnyDecimalSeparator`:  Similar to `NextDouble`, this parameter allows accepting both '.' and ',' as decimal separators when set to `true` (default). If `false`, only the system's default decimal separator is accepted.

* **`NextString()`**:
    Reads a quoted string from the console input. The string must be enclosed in double quotes (`"`). Supports escaped quotes within the string using a backslash (`\"`). Throws a `FormatException` if the input is not properly quoted.

* **`Create1DList()`**:
    Reads a space-separated list of numbers from the console input and returns them as a `List<decimal>`. The input for the list ends when two consecutive spaces are encountered. Supports various numeric types that can be parsed as decimals.

* **`Create2DList()`**:
    Reads a 2D list (list of lists) of decimal numbers from the console input. Each row of the matrix is entered as space-separated numbers, and rows are separated by pressing the Enter key. Input for the 2D list ends when two consecutive Enter keys are pressed.

* **`Create3DList()`**:
    Reads a 3D list (list of lists of lists) of decimal numbers from the console input. Each matrix within the 3D list is entered row by row (like `Create2DList`), and matrices are separated by two consecutive Enter keys. The entire 3D list input ends when three consecutive Enter keys are pressed.

## Usage Example

```csharp
using SimpleIO;
using System;
using System.Collections.Generic;

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
```

To use `SimpleIO`, simply include the `SimpleIO.cs` file in your C# project and use the static methods directly.

## Planned Features (TODOs)

The following features are planned for future releases of `SimpleIO`:

* x] TODO: Add more methods for reading arrays, jagged arrays, etc.
* TODO: Add methods for reading files, writing to files, etc.
* TODO: Add methods for reading from streams, writing to streams, etc.
* TODO: Add methods for reading from sockets, writing to sockets, etc.
* TODO: Add methods for reading from databases, writing to databases, etc.
* TODO: Add methods for reading from APIs, writing to APIs, etc.
* TODO: Add methods for reading from user input, writing to a user output file, etc.
* TODO: Add methods for reading from a user input stream, writing to a user output stream, etc.
* TODO: Add methods for reading from a user input socket, writing to a user output socket, etc.
* TODO: Add methods for reading from a user input database, writing to a user output database, etc.
* TODO: Add methods for reading from a user input API, writing to a user output API, etc.
* TODO: Add various math functions for linear algebra, statistics, numerical integration, differentiation and optimization, etc.
* TODO: Add various string functions for text processing, regular expressions, etc.
* TODO: Add various date and time functions for working with dates and times, etc.
* TODO: Add various graphics functions for drawing and rendering graphics, etc.
* TODO: Add various audio functions for playing and recording audio, etc.
* TODO: Add various video functions for playing and recording video, etc.

## License

[Choose a license, e.g., MIT License]

[**Example MIT License Snippet (Replace with your chosen license or remove this section if not open-sourcing)**]

```text
MIT License

Copyright (c) [2025] [Brett Smith]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
