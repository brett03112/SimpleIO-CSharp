# SimpleIO Test Documentation

This document describes the test cases and error handling for each method in the SimpleIO class.

## NextToken

***Purpose of NextToken**

Reads a token (word) from the console input, handling whitespace appropriately.

***Test Cases**

- Reading simple tokens
- Handling leading whitespace
- Handling trailing whitespace
- Empty input

***Error Handling**

- End of stream (-1) returns empty string
- Whitespace-only input returns empty string

## NextInt

***Purpose**

Reads an integer from the console input.

***Test Cases**

- Reading positive integers
- Reading negative integers
- Handling whitespace

***Error Handling**

- Throws FormatException for non-numeric input
- Throws OverflowException for values outside Int32 range

## NextDouble

***Purpose**

Reads a double-precision floating-point number from the console. Implemented efficiently by leveraging NextDecimal() and performing a type conversion.

***Test Cases**

- Reading numbers with dot decimal separator
- Reading numbers with comma decimal separator
- Reading whole numbers
- Reading negative numbers

***Error Handling**

- Throws FormatException for non-numeric input
- Accepts both '.' and ',' as decimal separators when acceptAnyDecimalSeparator is true
- Uses system culture decimal separator when acceptAnyDecimalSeparator is false
- Inherits robust error handling from NextDecimal()

## NextDecimal

***Purpose**

Reads a decimal number from the console.

***Test Cases**

- Reading numbers with dot decimal separator
- Reading numbers with comma decimal separator
- Reading whole numbers
- Reading negative numbers

***Error Handling**

- Throws FormatException for non-numeric input
- Accepts both '.' and ',' as decimal separators when acceptAnyDecimalSeparator is true
- Uses system culture decimal separator when acceptAnyDecimalSeparator is false

## NextString

***Purpose**

Reads a quoted string from the console, supporting escaped quotes.

***Test Cases**

- Reading simple quoted strings
- Reading strings with escaped quotes
- Reading strings with spaces

***Error Handling**

- Throws FormatException for missing opening quote
- Throws FormatException for missing closing quote
- Throws FormatException for end of input before closing quote
- Supports escape sequences with backslash

## Create1DList

***Purpose**

Creates a one-dimensional list of numbers from space-separated input.

***Test Cases**

- Reading space-separated numbers
- Reading mixed number formats (integers and decimals)
- Empty input

***Error Handling**

- Returns empty list for empty input
- Supports both '.' and ',' as decimal separators
- Stops reading on two consecutive spaces
- Throws FormatException for non-numeric values

## Create2DList

***Purpose**

Creates a two-dimensional list (matrix) of numbers, with rows separated by Enter key.

***Test Cases**

- Reading multiple rows of numbers
- Reading rows of different lengths
- Empty input
- Single row input

***Error Handling**

- Returns empty list for empty input
- Supports both '.' and ',' as decimal separators
- Ends input on two consecutive Enter keys
- Throws FormatException for non-numeric values
- Handles Windows-style line endings (\r\n)

## Create3DList

***Purpose**

Creates a three-dimensional list (array of matrices) of numbers, with matrices separated by double Enter key.

***Test Cases**

- Reading multiple matrices
- Reading matrices of different sizes
- Empty input
- Single matrix input

***Error Handling**

- Returns empty list for empty input
- Supports both '.' and ',' as decimal separators
- Ends input on three consecutive Enter keys
- Throws FormatException for non-numeric values
- Handles Windows-style line endings (\r\n)
- Properly handles matrices of different dimensions

## General Error Handling Considerations

1. Input Stream Errors
   - All methods handle end-of-stream conditions
   - Methods restore Console.In state after use
   - Buffer overflows are prevented by using StringBuilder

2. Number Parsing
   - All numeric methods support culture-invariant parsing
   - Decimal separator handling is consistent across methods
   - Range checking is performed for appropriate types
   - Efficient implementation by reusing parsing logic where possible

3. Memory Considerations
   - Lists are created with appropriate initial capacity
   - Resources are properly disposed
   - Stream handling is efficient
   - Optimized memory usage through method reuse

4. Platform Compatibility
   - Line ending handling is platform-aware
   - Culture-specific number formatting is handled
   - Console input/output is properly managed
   - Cross-platform decimal separator support

## Test Coverage

The test suite provides:

- Unit tests for all public methods
- Coverage of normal operation cases
- Coverage of edge cases and error conditions
- Verification of error handling
- Cross-platform compatibility testing

## Future Development

TODO: Package the library and publish it on the NuGet platform to make it easily accessible to other .NET developers. This will involve:

1. Creating a NuGet package specification
2. Setting up CI/CD for automated package publishing
3. Versioning strategy implementation
4. Package documentation and release notes
5. NuGet feed configuration and deployment
