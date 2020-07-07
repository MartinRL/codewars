namespace codewars
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using static System.Text.Encoding;
    using FluentAssertions;
    using Xunit;

    public static class EncryptThisSolution
    {
        private static string EncryptWord(string input)
        {
            switch (input.Length)
            {
                case 0:
                    return input;
                case 1:
                    return ASCII.GetBytes(input).First().ToString();
                case 2:
                    return string.Concat(new [] { ASCII.GetBytes(input).First().ToString(), input.Last().ToString() });
                default:
                    return string.Concat(new [] { ASCII.GetBytes(input).First().ToString(), input.Last().ToString(), string.Concat(input.Skip(2).Take(input.Length - 3)), input.Second().ToString() });
            }
        }

        public static string EncryptThis(string input)
        {
            return input.Split(' ').Select(EncryptWord).Aggregate((r, c) => $"{r} {c}");
        }
    }

    public static class EncryptThisExtensions
    {
        public static T Second<T>(this IEnumerable<T> @this) => @this.ElementAt(1);
    }

    public class EncryptThisTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("A", "65")]
        [InlineData("Ab", "65b")]
        [InlineData("Abc", "65cb")]
        [InlineData("Abcd", "65dcb")]
        [InlineData("A wise old owl lived in an oak", "65 119esi 111dl 111lw 108dvei 105n 97n 111ka")]
        [InlineData("The more he saw the less he spoke", "84eh 109ero 104e 115wa 116eh 108sse 104e 115eokp")]
        [InlineData("The less he spoke the more he heard", "84eh 108sse 104e 115eokp 116eh 109ero 104e 104dare")]
        [InlineData("Why can we not all be like that wise old bird", "87yh 99na 119e 110to 97ll 98e 108eki 116tah 119esi 111dl 98dri")]
        [InlineData("Thank you Piotr for all your help", "84kanh 121uo 80roti 102ro 97ll 121ruo 104ple")]
        public void VerifyEncryptThisWith(string input, string expectedEncryptedOutput) => EncryptThisSolution.EncryptThis(input).Should().Be(expectedEncryptedOutput);
    }
}
