using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class MapSolution
    {
        public static Node<T2> Map<T, T2>(Node<T> head, Func<T, T2> f) 
        {
            return null;
        }
    }
    
    public class Node<T> 
    {
        public readonly T Data;
        public readonly Node<T> Next;

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
    }

    public class MapTests
    {
        [Fact]
        public void VerifyMapWithNull()
        {
            MapSolution.Map<string, string>(null, x => x).Should().BeNull();
        }
        
        [Fact]
        public void VerifyMapWithDoNothingFunc()
        {
            ToList(MapSolution.Map<int, int>(new Node<int>(1, new Node<int>(2, new Node<int>(3))), _ => _))
                .Should().Equal(ToList(new Node<int>(1, new Node<int>(2, new Node<int>(3)))));
        }
        
        private static List<Node<T>> ToList<T>(Node<T> head)
        {
            var list = new List<Node<T>>();
            var next = head;
            
            while (next != null)
            {
                list.Add(next);
                next = next.Next;
            }
            
            return list;
        }
    }
}
