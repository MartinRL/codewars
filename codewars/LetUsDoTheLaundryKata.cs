namespace codewars;


// Define the interfaces for different types of clothes
public interface IClothing
{
    int WashedCount { get; }
}

public interface ISocks : IClothing { }

public interface IShirt : IClothing { }

public interface ITrowers : IClothing { }

public interface IForged : IClothing { }

// Define the classes for different kinds of clothes
public class SportSocks(int washedCount) : ISocks
{
    public int WashedCount { get; } = washedCount;
}

public class SilkSocks(int washedCount) : ISocks, IForged
{
    public int WashedCount { get; } = washedCount;
}

public class ShortTrowsers(int washedCount) : ITrowers
{
    public int WashedCount { get; } = washedCount;
}

public class ShortSleevedShirt(int washedCount) : IShirt
{
    public int WashedCount { get; } = washedCount;
}

public class LongSleevedShirt(int washedCount) : IShirt
{
    public int WashedCount { get; } = washedCount;
}

// Define the class for the laundry basket
public class Laundry
{
    private List<IClothing> clothes;
    private List<IClothing> disposed;

    public Laundry()
    {
        clothes = [];
        disposed = [];
    }

    public void FillLaundryBasket(List<IClothing> clothes) => this.clothes.AddRange(clothes);

    public void LetMotherWashTheClothes()
    {
        disposed = clothes.Where(_ => (_ is IForged && _.WashedCount >= 25) || _.WashedCount >= 40).ToList();
        clothes = clothes.Except(disposed).ToList();
    }

    public List<IClothing> Disposed => disposed;

    public int GetSpecificClothes<T>() where T : IClothing => clothes.Count(c => c is T);
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
