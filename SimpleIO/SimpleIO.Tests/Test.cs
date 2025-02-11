using System;
using System.IO;
using System.Text;
using Xunit;
using SimpleIO;

namespace SimpleIO.Tests;

public class SimpleIOTests : IDisposable
{
    private readonly TextReader originalIn;
    private StringReader? stringReader;

    public SimpleIOTests()
    {
        originalIn = Console.In;
    }

    public void Dispose()
    {
        Console.SetIn(originalIn);
        stringReader?.Dispose();
    }

    private void SetInput(string input)
    {
        stringReader?.Dispose();
        stringReader = new StringReader(input);
        Console.SetIn(stringReader);
    }

    #region NextToken Tests
    [Fact(DisplayName = "NextToken should read a simple token")]
    public void NextToken_ShouldReadSimpleToken()
    {
        // Arrange
        SetInput("hello");

        // Act
        string result = SimpleIO.NextToken();

        // Assert
        Assert.Equal("hello", result);
    }

    [Fact(DisplayName = "NextToken should skip leading whitespace")]
    public void NextToken_ShouldSkipLeadingWhitespace()
    {
        SetInput("   hello");
        Assert.Equal("hello", SimpleIO.NextToken());
    }

    [Fact(DisplayName = "NextToken should stop at trailing whitespace")]
    public void NextToken_ShouldStopAtTrailingWhitespace()
    {
        SetInput("hello world");
        Assert.Equal("hello", SimpleIO.NextToken());
    }

    [Fact(DisplayName = "NextToken should handle empty input")]
    public void NextToken_ShouldHandleEmptyInput()
    {
        SetInput("");
        Assert.Equal("", SimpleIO.NextToken());
    }
    #endregion

    #region NextInt Tests
    [Fact(DisplayName = "NextInt should read valid integer")]
    public void NextInt_ShouldReadValidInteger()
    {
        SetInput("42");
        Assert.Equal(42, SimpleIO.NextInt());
    }

    [Fact(DisplayName = "NextInt should throw on invalid input")]
    public void NextInt_ShouldThrowOnInvalidInput()
    {
        SetInput("not a number");
        Assert.Throws<FormatException>(() => SimpleIO.NextInt());
    }

    [Fact(DisplayName = "NextInt should handle negative numbers")]
    public void NextInt_ShouldHandleNegativeNumbers()
    {
        SetInput("-42");
        Assert.Equal(-42, SimpleIO.NextInt());
    }
    #endregion

    #region NextDouble Tests
    [Fact(DisplayName = "NextDouble should read valid double with dot")]
    public void NextDouble_ShouldReadValidDoubleWithDot()
    {
        SetInput("3.14");
        Assert.Equal(3.14, SimpleIO.NextDouble());
    }

    [Fact(DisplayName = "NextDouble should read valid double with comma")]
    public void NextDouble_ShouldReadValidDoubleWithComma()
    {
        SetInput("3,14");
        Assert.Equal(3.14, SimpleIO.NextDouble());
    }

    [Fact(DisplayName = "NextDouble should throw on invalid input")]
    public void NextDouble_ShouldThrowOnInvalidInput()
    {
        SetInput("not a number");
        Assert.Throws<FormatException>(() => SimpleIO.NextDouble());
    }
    #endregion

    #region NextDecimal Tests
    [Fact(DisplayName = "NextDecimal should read valid decimal with dot")]
    public void NextDecimal_ShouldReadValidDecimalWithDot()
    {
        SetInput("3.14");
        Assert.Equal(3.14m, SimpleIO.NextDecimal());
    }

    [Fact(DisplayName = "NextDecimal should read valid decimal with comma")]
    public void NextDecimal_ShouldReadValidDecimalWithComma()
    {
        SetInput("3,14");
        Assert.Equal(3.14m, SimpleIO.NextDecimal());
    }

    [Fact(DisplayName = "NextDecimal should throw on invalid input")]
    public void NextDecimal_ShouldThrowOnInvalidInput()
    {
        SetInput("not a number");
        Assert.Throws<FormatException>(() => SimpleIO.NextDecimal());
    }
    #endregion

    #region NextString Tests
    [Fact(DisplayName = "NextString should read quoted string")]
    public void NextString_ShouldReadQuotedString()
    {
        SetInput("\"hello world\"");
        Assert.Equal("hello world", SimpleIO.NextString());
    }

    [Fact(DisplayName = "NextString should handle escaped quotes")]
    public void NextString_ShouldHandleEscapedQuotes()
    {
        SetInput("\"hello \\\"world\\\"\"");
        Assert.Equal("hello \"world\"", SimpleIO.NextString());
    }

    [Fact(DisplayName = "NextString should throw on missing opening quote")]
    public void NextString_ShouldThrowOnMissingOpeningQuote()
    {
        SetInput("hello\"");
        Assert.Throws<FormatException>(() => SimpleIO.NextString());
    }

    [Fact(DisplayName = "NextString should throw on missing closing quote")]
    public void NextString_ShouldThrowOnMissingClosingQuote()
    {
        SetInput("\"hello");
        Assert.Throws<FormatException>(() => SimpleIO.NextString());
    }
    #endregion

    #region Create1DList Tests
    [Fact(DisplayName = "Create1DList should read space-separated numbers")]
    public void Create1DList_ShouldReadSpaceSeparatedNumbers()
    {
        SetInput("1 2 3  ");
        var result = SimpleIO.Create1DList();
        Assert.Equal(new[] { 1m, 2m, 3m }, result);
    }

    [Fact(DisplayName = "Create1DList should handle empty input")]
    public void Create1DList_ShouldHandleEmptyInput()
    {
        SetInput("");
        var result = SimpleIO.Create1DList();
        Assert.Empty(result);
    }

    [Fact(DisplayName = "Create1DList should handle mixed number formats")]
    public void Create1DList_ShouldHandleMixedNumberFormats()
    {
        SetInput("1 2.5 3,14  ");
        var result = SimpleIO.Create1DList();
        Assert.Equal(new[] { 1m, 2.5m, 3.14m }, result);
    }
    #endregion

    #region Create2DList Tests
    [Fact(DisplayName = "Create2DList should read multiple rows")]
    public void Create2DList_ShouldReadMultipleRows()
    {
        SetInput("1 2 3\n4 5 6\n\n");
        var result = SimpleIO.Create2DList();
        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 1m, 2m, 3m }, result[0]);
        Assert.Equal(new[] { 4m, 5m, 6m }, result[1]);
    }

    [Fact(DisplayName = "Create2DList should handle empty input")]
    public void Create2DList_ShouldHandleEmptyInput()
    {
        SetInput("\n\n");
        var result = SimpleIO.Create2DList();
        Assert.Empty(result);
    }

    [Fact(DisplayName = "Create2DList should handle rows with different lengths")]
    public void Create2DList_ShouldHandleRowsWithDifferentLengths()
    {
        SetInput("1 2\n3 4 5\n\n");
        var result = SimpleIO.Create2DList();
        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 1m, 2m }, result[0]);
        Assert.Equal(new[] { 3m, 4m, 5m }, result[1]);
    }
    #endregion

    #region Create3DList Tests
    [Fact(DisplayName = "Create3DList should read multiple matrices")]
    public void Create3DList_ShouldReadMultipleMatrices()
    {
        SetInput("1 2\n3 4\n\n5 6\n7 8\n\n\n");
        var result = SimpleIO.Create3DList();
        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { 1m, 2m }, result[0][0]);
        Assert.Equal(new[] { 3m, 4m }, result[0][1]);
        Assert.Equal(new[] { 5m, 6m }, result[1][0]);
        Assert.Equal(new[] { 7m, 8m }, result[1][1]);
    }

    [Fact(DisplayName = "Create3DList should handle empty input")]
    public void Create3DList_ShouldHandleEmptyInput()
    {
        SetInput("\n\n\n");
        var result = SimpleIO.Create3DList();
        Assert.Empty(result);
    }

    [Fact(DisplayName = "Create3DList should handle matrices with different sizes")]
    public void Create3DList_ShouldHandleMatricesWithDifferentSizes()
    {
        SetInput("1 2\n3 4\n\n5\n6 7\n\n\n");
        var result = SimpleIO.Create3DList();
        Assert.Equal(2, result.Count);
        Assert.Equal(2, result[0].Count);
        Assert.Equal(2, result[1].Count);
        Assert.Equal(new[] { 1m, 2m }, result[0][0]);
        Assert.Equal(new[] { 3m, 4m }, result[0][1]);
        Assert.Equal(new[] { 5m }, result[1][0]);
        Assert.Equal(new[] { 6m, 7m }, result[1][1]);
    }
    #endregion
}
