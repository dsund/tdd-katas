using System;
using System.Linq;

namespace StringCalculatorTest
{
  public class StringCalculator
  {
    public static int Add(string numbers)
    {

      if (numbers == "")
        return 0;

      var delimiter = ',';
      if (numbers.StartsWith("//"))
      {
        delimiter = numbers[2];
        numbers = numbers.Substring(4);
      }
      var arrOfNum = numbers.Replace('\n', delimiter).Split(delimiter).Select(x => int.Parse(x)).ToArray();
      
      Validate(arrOfNum, delimiter);

      return numbers.Replace('\n', delimiter).Split(delimiter).Sum(n => int.Parse(n));
    }

    private static void Validate(int[] numbers, char delimiter)
    {
      var negatives = numbers.Where(x => x < 0);
      if (negatives.Any())
      {
        throw new ArgumentException($"Negatives not allowed [{string.Join(", ", negatives)}]");
      }
    }
  }
}