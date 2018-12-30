using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class BestTravelKata
    {
        public static int? chooseBestSum(int t, int k, List<int> ls) 
        {
            throw new NotImplementedException();
        }
    }
    
    abstract class ImmutableStack<T>: IEnumerable<T>
    {
        public static readonly ImmutableStack<T> Empty = new EmptyStack();
        private ImmutableStack() {}
        public abstract ImmutableStack<T> Pop();
        public abstract T Top { get; }
        public abstract bool IsEmpty { get; }
        public IEnumerator<T> GetEnumerator()
        {
            var current = this;
            while(!current.IsEmpty)
            {
                yield return current.Top;
                current = current.Pop();
            }    
        }
        IEnumerator IEnumerable.GetEnumerator() 
        { 
            return this.GetEnumerator(); 
        }
        public ImmutableStack<T> Push(T value)
        {
            return new NonEmptyStack(value, this);
        }
        private class EmptyStack: ImmutableStack<T>
        {
            public override ImmutableStack<T> Pop()
            { 
                throw new InvalidOperationException(); 
            }
            public override T Top 
            { 
                get { throw new InvalidOperationException(); } 
            }
            public override bool IsEmpty { get { return true; } }
        } 
        private class NonEmptyStack : ImmutableStack<T>
        {
            private readonly T head;
            private readonly ImmutableStack<T> tail;
            public NonEmptyStack(T head, ImmutableStack<T> tail)
            {
                this.head = head;
                this.tail = tail;
            }
            public override ImmutableStack<T> Pop() { return this.tail; }
            public override T Top { get { return this.head; } }
            public override bool IsEmpty { get { return false; } } 
        }
    }

    public static class IEnumerableExtensions
    {
        private static IEnumerable<ImmutableStack<bool>> Combinations(int n, int k)
        {
            if (k == 0 && n == 0)
            { 
                yield return ImmutableStack<bool>.Empty;
                yield break;
            }
            if (n < k)
                yield break;
        }

        private static IEnumerable<T> ZipWhere<T>(this IEnumerable<T> items, IEnumerable<bool> selectors)
        {
            using (var e1 = items.GetEnumerator())
            using (var e2 = selectors.GetEnumerator())
                while (e1.MoveNext() && e2.MoveNext())
                    if (e2.Current)
                        yield return e1.Current;
        }
        
        public static IEnumerable<IEnumerable<T>> CombinationsOf<T>(this IEnumerable<T> @this, int k)
        {
            return 
                from combination in Combinations(@this.Count(), k)
                select @this.ZipWhere(combination);
        }
    }

    public class BestTravelTests
    {
        [Theory]
        [InlineData(163, 3, new [] { 50, 55, 56, 57, 58 }, 163)]
        [InlineData(163, 3, new [] { 50 }, null)]
        [InlineData(230, 3, new [] { 91, 74, 73, 85, 73, 81, 87 }, 228)]
        public void ExecuteChooseBestSumExample(int t, int k, int[] ls, int? expected)
        {
            BestTravelKata.chooseBestSum(t, k, ls.ToList()).Should().Be(expected);
        }

        [Fact]
        public void CombinationsOfShouldReturnAllCombinationsOfThree()
        {
            new [] {50, 55, 57, 58, 60}.CombinationsOf(3).Should().AllBeEquivalentTo(new [] 
            { 
                new [] {50, 55, 57},  
                new [] {50, 55, 58},  
                new [] {50, 55, 60},  
                new [] {50, 57, 58},  
                new [] {50, 57, 60},  
                new [] {50, 58, 60},  
                new [] {55, 57, 58},  
                new [] {55, 57, 60},  
                new [] {55, 58, 60},  
                new [] {57, 58, 60} 
             });
        }
    }
}
