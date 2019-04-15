using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class MapSolution
    {
        public static Node<T2> Map<T, T2>(Node<T> head, Func<T, T2> f) 
        {
            if (head == null)
                return null;

            var next = head;
            var headT2 = new Node<T2>(f(head.Data));
            var nextT2 = headT2;
            while (next != null)
            {
                if (next.Next != null)
                {
                    nextT2.Next = new Node<T2>(f(next.Next.Data));
                }
                
                next = next.Next;
                nextT2 = nextT2.Next;
            }

            return headT2;
        }
    }
    
    public class Node<T> 
    {
        public T Data;
        public Node<T> Next;

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
            ToList(MapSolution.Map(new Node<int>(1, new Node<int>(2, new Node<int>(3))), _ => _))
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
