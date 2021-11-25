namespace codewars;

public static class EncryptThisSolution
{
    private static string Encrypt(string word) => word.Length switch
    {
        0 => word,
        1 => $"{(int)word[0]}",
        2 => $"{(int)word[0]}{word[1]}",
        _ => $"{(int)word[0]}{word[^1]}{word[2..^1]}{word[1]}"
    };

    public static string EncryptThis(string input)
    {
        return input.Split(' ').Select(Encrypt).Aggregate((r, c) => $"{r} {c}");
    }
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