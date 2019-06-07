using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class RemovingElementsSolution
    {
        public static object[] RemoveEveryOther(object[] arr)
        {
            throw new NotImplementedException();
        }
    }

    public class RemovingElementsTests
    {
        [Theory]
        [InlineData(new object[]{"Hello", "Goodbye", "Hello Again"}, new object[]{"Hello", "Hello Again"})]
        [InlineData(new object[] { new object[] { 1, 2 } }, new object[] { new object[] { 1, 2 } })]
        [InlineData(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new object[] { 1, 3, 5, 7, 9 })]
        [InlineData(new object[] { }, new object[] { })]
        //[InlineData(new object[] { new object[] { "Goodbye" }, new Dictionary<string,string>(){{"Great", "Job"}}}, new object[] { new object[] { "Goodbye" } })]
        public void VerifyRemoveEveryOtherWith(object[] arr, object[] expectedWithEveryOtherRemoved)
        {
            RemovingElementsSolution.RemoveEveryOther(arr).Should().BeEquivalentTo(expectedWithEveryOtherRemoved);
        }
    }
}
