namespace codewars;

public class Laundry
{
    private List<IClothing> clothes;

    public List<IClothing> Disposed { get; set; }

    public void FillLaundryBasket(List<IClothing> clothes) => this.clothes = clothes;

    public void LetMotherWashTheClothes()
    {
        throw new NotImplementedException();
    }

    public object GetSpecificClothes<T>()
    {
        throw new NotImplementedException();
    }
}

public interface IClothing
{
    int WashedCount { get; }
}

public interface ITrowers : IClothing
{
}

public interface IShirt : IClothing
{
}

public interface ISocks : IClothing
{
}

public interface IForged
{
}

public class LongSleevedShirt(int washedCount) : IShirt
{
    public int WashedCount => washedCount;
}

public class ShortTrowsers(int washedCount) : ITrowers
{
    public int WashedCount => washedCount;
}

public class SilkSocks(int washedCount) : ISocks
{
    public int WashedCount => washedCount;
}

public class LetUsDoTheLaundryTests
{
    [Fact]
    public void VerifyLaundrySpec()
    {
        List<IClothing> clothes =
        [
            new SilkSocks(20),
            new SilkSocks(25),
            new SilkSocks(35),
            new SilkSocks(40),
            new ShortTrowsers(20),
            new ShortTrowsers(25),
            new ShortTrowsers(35),
            new ShortTrowsers(40),
            new LongSleevedShirt(20),
            new LongSleevedShirt(25),
            new LongSleevedShirt(35),
            new LongSleevedShirt(40)
        ];

        Laundry laundry = new();
        laundry.FillLaundryBasket(new List<IClothing>(clothes));
        laundry.LetMotherWashTheClothes();

        laundry.Disposed.Count().Should().Be(5, "Remember to dispose the correct clothes");
        laundry.GetSpecificClothes<IForged>().Should().Be(1, "forged");
        laundry.GetSpecificClothes<IClothing>().Should().Be(7, "clothing");
        laundry.GetSpecificClothes<ISocks>().Should().Be(1, "socks");
        laundry.GetSpecificClothes<IShirt>().Should().Be(3, "shirts");
        laundry.GetSpecificClothes<ITrowers>().Should().Be(3, "trowsers");
    }
}
