public class Laundry
{
    private List<IClothing> _clothes;
    public List<IClothing> Disposed { get; set; }

    //Create the washing things here!
}

public class LetUsDoTheLaundryTests
{
    [Fact]
    public void SmallTest()
    {
        List<IClothing> testClothes = new List<IClothing>
        {
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
        };

        Laundry laundry = new Laundry();
        laundry.FillLaundryBasket(new List<IClothing>(testClothes));
        laundry.LetMotherWashTheClothes();

        laundry.Disposed.Count().Should().Be(5, "Remember to dispose the correct clothes");
        laundry.GetSpecificClothes<IForged>().Should().Be(1, "forged");
        laundry.GetSpecificClothes<IClothing>().Should().Be(7, "clothing");
        laundry.GetSpecificClothes<ISocks>().Should().Be(1, "socks");
        laundry.GetSpecificClothes<IShirt>().Should().Be(3, "shirts");
        laundry.GetSpecificClothes<ITrowers>().Should().Be(3, "trowsers");
    }
}
