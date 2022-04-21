using FluentAssertions;
using System;
using Xunit;

namespace StringCalculatorTest
{
  public class StringCalculatorAddTest
  {
    [Fact]
    public void ShouldReturnZeroWhenEmptyString()
    {
      StringCalculator.Add("").Should().Be(0);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    [InlineData("3,4", 7)]
    [InlineData("5,6", 11)]
    [InlineData("1,6,3", 10)]
    public void ShouldAddStringWithNumbers(string numbers, int result)
    {
      StringCalculator.Add(numbers).Should().Be(result);
    }

    [Fact]
    public void ShouldAddNumbersWithNewLineSeparator()
    {
      StringCalculator.Add("1\n2,3").Should().Be(6);
    }

    [Fact]
    public void ShouldAddNumbersWithSuppliedSeparator()
    {
      StringCalculator.Add("//;\n1;2;3").Should().Be(6);
    }

    [Fact]
    public void ShouldThrowOnNegativeInput()
    {
      var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add("-1, 3, -2"));
      ex.Message.Should().Be("Negatives not allowed [-1, -2]");
    }
  }
}