using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Replace("//", string.Empty);

                if (numbers[0] == '[')
                {
                    numbers = numbers.Remove(0, 1);
                    var idx = numbers.IndexOf(']');
                    var customDelimiter = numbers.Substring(0, idx);
                    delimiters.Add(customDelimiter);
                    numbers = numbers.Remove(0, idx + 1);
                }
                else
                {
                    var customDelimiter = numbers[0].ToString();
                    delimiters.Add(customDelimiter);
                    numbers = numbers.Remove(0, 1);
                }
            }

            var splitNumbers = numbers
              .Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToList();

            var negativeNumbers = splitNumbers.Where(x => x < 0).ToList();

            if (negativeNumbers.Any())
                throw new Exception();

            splitNumbers.RemoveAll(x => x > 1000);

            return splitNumbers.Sum();
        }
    }
}
