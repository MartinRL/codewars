namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ItemCounter<T>
    {
        //private readonly Dictionary<T, int> _itemCounts = new Dictionary<T, int>();

        public int DistinctItems
        {
            get { throw new NotImplementedException(); }
        }

        public int GetCount(T item)
        {
            throw new NotImplementedException();
        }

        public bool HasItem(T item)
        {
            throw new NotImplementedException();
        }


        public ItemCounter(T[] items)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemCounterTests
    {
        [Fact]
        public void GivenACallToConstructor_WhenPassedNullArgument_ThrowsArgumentNullException()
        {
            Action act = () => new ItemCounter<string>(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DistinctItems_AfterConstructionWithEmptyArray_IsZero()
        {
            var items = new string[] { };
            var counter = new ItemCounter<string>(items);

            counter.DistinctItems.Should().Be(0);
        }

        [Fact]
        public void DistinctItems_AfterConstructionWithTwoSameItemsArray_IsOne()
        {
            var items = new[] { "Apple", "Apple" };
            var counter = new ItemCounter<string>(items);

            counter.DistinctItems.Should().Be(1);
        }

        [Fact]
        public void DistinctItems_AfterConstructionWithTwoDifferentItemsArray_IsTwo()
        {
            var items = new[] { "Apple", "Orange" };
            var counter = new ItemCounter<string>(items);

            counter.DistinctItems.Should().Be(2);
        }

        [Fact]
        public void DistinctItems_AfterConstructionWithThreeItemsTwoSameAndOneDifferen_IsTwo()
        {
            var items = new[] { "Apple", "Orange", "Apple", };
            var counter = new ItemCounter<string>(items);

            counter.DistinctItems.Should().Be(2);
        }

        [Fact]
        public void GetCount_AfterConstructionWithTwoSameItemsArray_IsTwo()
        {
            var item1 = "Apple";
            var item2 = item1;
            var items = new[] { item1, item2 };
            var counter = new ItemCounter<string>(items);

            counter.GetCount(item1).Should().Be(2);
        }

        [Fact]
        public void GetCount_AfterConstructionWithTwoDifferentItemsArray_IsOne()
        {
            var item1 = "Apple";
            var item2 = "Banana";
            var items = new[] { item1, item2 };
            var counter = new ItemCounter<string>(items);

            counter.GetCount(item1).Should().Be(1);
        }

        [Fact]
        public void GetCount_WhenSpecifyingNonExistingItem_ThrowsException()
        {
            var items = new[] { "Apple", "Apple" };
            var counter = new ItemCounter<string>(items);

            Action act = () => counter.GetCount("Pear");

            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void GetCount_WhenSpecifyingNullItem_ThrowsException()
        {
            var items = new[] { "Apple", "Apple" };
            var counter = new ItemCounter<string>(items);

            Action act = () => counter.GetCount(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void HasItem_WhenItemExists_ReturnsTrue()
        {
            var item = "Apple";
            var items = new[] { item };
            var counter = new ItemCounter<string>(items);

            counter.HasItem(item).Should().BeTrue();
        }

        [Fact]
        public void HasItem_WhenItemDoesNotExist_ReturnsFalse()
        {
            var item1 = "Apple";
            var item2 = "Pear";
            var items = new[] {item1};
            var counter = new ItemCounter<string>(items);

            counter.HasItem(item2).Should().BeFalse();
        }
    }
}
