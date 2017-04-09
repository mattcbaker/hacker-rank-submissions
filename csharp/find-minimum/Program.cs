using System;
using System.Linq;
using Xunit;

class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(MinimumFinder.Execute(n));
    }
}

class MinimumFinder
{
    public static string Execute(int input)
    {
        return Enumerable.Range(2, input - 1)
            .Aggregate("int", ((state, _) => $"min(int, {state})"));
    }
}

public class Tests
{
    [Fact]
    public void should_handle_two()
    {
        var actual = MinimumFinder.Execute(2);

        Assert.Equal("min(int, int)", actual);
    }

    [Theory]
    [InlineData(3, "min(int, min(int, int))")]
    [InlineData(4, "min(int, min(int, min(int, int)))")]
    public void should_handle_inputs_greather_than_two(int input, string expected)
    {
        var actual = MinimumFinder.Execute(input);

        Assert.Equal(actual, expected);
    }
}