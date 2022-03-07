using FluentAssertions;
using System;
using Xunit;

namespace StringCalculator.Tests
{
    
        public class CalculatorTests
        {
            [Theory]
            [InlineData("", 0)]
            public void empty_sting_should_return_0(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("1", 1)]
            public void single_number_should_return_value(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("1,2", 3)]
            public void two_numbers_comma_delimited_returns_sum(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }


            [Theory]
            [InlineData("1\n2", 3)]
            public void two_numbers_newline_delimited_returns_sum(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("1,2,3", 6)]
            public void three_numbers_delimited_either_way_returns_sum(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("1,2,-1", -1)]
            public void negative_numbers_throw_an_exception(string calculation, int expected)
            {
                var sut = new Calculator();

                Action action = () => sut.Add(calculation);

                action.Should().Throw<Exception>();
            }

            [Theory]
            [InlineData("1,1001,1000", 1001)]
            public void numbers_greater_than_1000_are_ignored(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }


            [Theory]
            [InlineData("//;1;2", 3)]
            public void single_char_delimiter_can_be_defined_on_the_first_line(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }

            [Theory]
            [InlineData("//[###]1###2", 3)]
            public void multi_char_delimiter_can_be_defined_on_the_first_line(string calculation, int expected)
            {
                var sut = new Calculator();

                var result = sut.Add(calculation);

                result.Should().Be(expected);
            }
        }
}
