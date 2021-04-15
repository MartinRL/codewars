namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public enum Result { Win, Loss, Tie }

    public enum HandValue { None, Pair, TwoPairs, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush }

    public class Card : IComparable<Card>
    {
        private readonly char valueChar;
        private readonly char suitChar;

        public Card(string card)
        {
            valueChar = card.First();
            suitChar = card.Last();
        }

        public byte Value
        {
            get
            {
                if (valueChar == 'T')
                    return 10;

                if (valueChar == 'J')
                    return 11;

                if (valueChar == 'Q')
                    return 12;

                if (valueChar == 'K')
                    return 13;

                if (valueChar == 'A')
                    return 14;

                return (byte)(Convert.ToByte(valueChar) - Convert.ToByte('0'));
            }
        }

        public enum Suits { Clubs, Diamonds, Spades, Hearts }

        public Suits Suit => suitChar switch
            {
                'S' => Suits.Spades,
                'H' => Suits.Hearts,
                'D' => Suits.Diamonds,
                _ => Suits.Clubs
            };

        public int CompareTo(Card other)
        {
            if (Value > other.Value)
                return 1;

            if (Value == other.Value)
                return 0;

            return -1;
        }

        public override bool Equals(object obj) => Value == ((Card) obj).Value && Suit == ((Card) obj).Suit;

        public override int GetHashCode() => Value.GetHashCode() * 17 + Suit.GetHashCode();

        public override string ToString() => $"{Suit.ToString()} {Value.ToString()}";
    }

    public class PokerHand
    {
        private readonly IEnumerable<Card> cards;

        public PokerHand(string hand) => this.cards = hand.Split(" ").Select(card => new Card(card)).OrderBy(_ => _).ToArray();

        public HandValue HandValue
        {
            get
            {
                if (cards.GroupBy(c => c.Suit).Select(g => g.Count()).Max() == 5 && cards.Max(c => c.Value) - cards.Min(c => c.Value) == 4 && cards.Max(c => c.Value) == 14)
                    return HandValue.RoyalFlush;

                if (cards.GroupBy(c => c.Suit).Select(g => g.Count()).Max() == 5 && cards.Max(c => c.Value) - cards.Min(c => c.Value) == 4)
                    return HandValue.StraightFlush;

                if (cards.GroupBy(c => c.Value).Select(g => g.Count()).Max() == 4)
                    return HandValue.FourOfAKind;

                if (cards.GroupBy(c => c.Value).Select(g => g.Count()).Max() == 3 && cards.GroupBy(c => c.Value).Select(g => g.Count()).Min() == 2)
                    return HandValue.FullHouse;

                if (cards.GroupBy(c => c.Suit).Select(g => g.Count()).Max() == 5)
                    return HandValue.Flush;

                if (cards.GroupBy(c => c.Value).Select(g => g.Count()).Max() == 1 && cards.Max(c => c.Value) - cards.Min(c => c.Value) == 4)
                    return HandValue.Straight;

                if (cards.GroupBy(c => c.Value).Select(g => g.Count()).Max() == 3)
                    return HandValue.ThreeOfAKind;

                if (cards.GroupBy(c => c.Value).Select(g => g.Count()).Count() == 3)
                    return HandValue.TwoPairs;

                if (cards.GroupBy(c => c.Value).Select(g => g.Count()).Count() == 4)
                    return HandValue.Pair;

                return HandValue.None;
            }
        }

        public Result CompareWith(PokerHand hand)
        {
            if (HandValue > hand.HandValue)
                return Result.Win;

            if (HandValue < hand.HandValue)
                return Result.Loss;

            if (HandValue == hand.HandValue)
            {
                if (HandValue == HandValue.ThreeOfAKind || HandValue == HandValue.FourOfAKind ||
                    HandValue == HandValue.FullHouse)
                    return cards.GroupBy(c => c.Value).OrderByDescending(g => g.Count()).First().Key >
                           hand.cards.GroupBy(c => c.Value).OrderByDescending(g => g.Count()).First().Key
                        ? Result.Win : Result.Loss;

                if (HandValue == HandValue.StraightFlush || HandValue == HandValue.Flush)
                {
                    if (this.cards.ElementAt(4).Value > hand.cards.ElementAt(4).Value)
                        return Result.Win;

                    if (this.cards.ElementAt(4).Value < hand.cards.ElementAt(4).Value)
                        return Result.Loss;
                }
            }

            if (HandValue == HandValue.None && hand.HandValue == HandValue.None)
            {
                if (this.cards.Select(c => c.Value).SequenceEqual(hand.cards.Select(c => c.Value)))
                    return Result.Tie;

                if (this.cards.ElementAt(4).Value > hand.cards.ElementAt(4).Value)
                    return Result.Win;

                if (this.cards.ElementAt(4).Value < hand.cards.ElementAt(4).Value)
                    return Result.Loss;

                if (this.cards.ElementAt(4).Value > hand.cards.ElementAt(3).Value)
                    return Result.Win;

                if (this.cards.ElementAt(4).Value < hand.cards.ElementAt(3).Value)
                    return Result.Loss;

                if (this.cards.ElementAt(4).Value > hand.cards.ElementAt(2).Value)
                    return Result.Win;

                if (this.cards.ElementAt(4).Value < hand.cards.ElementAt(2).Value)
                    return Result.Loss;

                if (this.cards.ElementAt(4).Value > hand.cards.ElementAt(1).Value)
                    return Result.Win;

                if (this.cards.ElementAt(4).Value < hand.cards.ElementAt(1).Value)
                    return Result.Loss;

                if (this.cards.ElementAt(4).Value > hand.cards.ElementAt(0).Value)
                    return Result.Win;

                if (this.cards.ElementAt(4).Value < hand.cards.ElementAt(0).Value)
                    return Result.Loss;
            }

            return Result.Tie;
        }
    }

    public class RankingPokerHandsTests
    {
        [Theory]
        [InlineData("Highest straight flush wins", Result.Loss, "2H 3H 4H 5H 6H", "KS AS TS QS JS")]
        [InlineData("Straight flush wins of 4 of a kind", Result.Win, "2H 3H 4H 5H 6H", "AS AD AC AH JD")]
        [InlineData("Highest 4 of a kind wins", Result.Win, "AS AH 2H AD AC", "JS JD JC JH 3D")]
        [InlineData("4 Of a kind wins of full house", Result.Loss, "2S AH 2H AS AC", "JS JD JC JH AD")]
        [InlineData("Full house wins of flush", Result.Win, "2S AH 2H AS AC", "2H 3H 5H 6H 7H")]
        [InlineData("Highest flush wins", Result.Win, "AS 3S 4S 8S 2S", "2H 3H 5H 6H 7H")]
        [InlineData("Flush wins of straight", Result.Win, "2H 3H 5H 6H 7H", "2S 3H 4H 5S 6C")]
        [InlineData("Equal straight is tie", Result.Tie, "2S 3H 4H 5S 6C", "3D 4C 5H 6H 2S")]
        [InlineData("Straight wins of three of a kind", Result.Win, "2S 3H 4H 5S 6C", "AH AC 5H 6H AS")]
        [InlineData("3 Of a kind wins of two pair", Result.Loss, "2S 2H 4H 5S 4C", "AH AC 5H 6H AS")]
        [InlineData("2 Pair wins of pair", Result.Win, "2S 2H 4H 5S 4C", "AH AC 5H 6H 7S")]
        [InlineData("Highest pair wins", Result.Loss, "6S AD 7H 4S AS", "AH AC 5H 6H 7S")]
        [InlineData("Pair wins of nothing", Result.Loss, "2S AH 4H 5S KC", "AH AC 5H 6H 7S")]
        [InlineData("Highest card loses", Result.Loss, "2S 3H 6H 7S 9C", "7H 3C TH 6H 9S")]
        [InlineData("Highest card wins", Result.Win, "4S 5H 6H TS AC", "3S 5H 6H TS AC")]
        [InlineData("Equal cards is tie", Result.Tie, "2S AH 4H 5S 6C", "AD 4C 5H 6H 2C")]
        public void VerifyCompareWithWith(string because, Result expectedResult, string hand, string opponentHand) =>
            new PokerHand(hand).CompareWith(new PokerHand(opponentHand)).Should().Be(expectedResult, because);

        [Theory]
        [InlineData("2H 3H 4H 5H 6H", HandValue.StraightFlush)]
        [InlineData("KS AS TS QS JS", HandValue.RoyalFlush)]
        [InlineData("AS AD AC AH JD", HandValue.FourOfAKind)]
        [InlineData("2S AH 2H AS AC", HandValue.FullHouse)]
        [InlineData("AS 3S 4S 8S 2S", HandValue.Flush)]
        [InlineData("2S 3H 4H 5S 6C", HandValue.Straight)]
        [InlineData("AH AC 5H 6H AS", HandValue.ThreeOfAKind)]
        [InlineData("2S 2H 4H 5S 4C", HandValue.TwoPairs)]
        [InlineData("AH AC 5H 6H 7S", HandValue.Pair)]
        public void VerifyHandValueWith(string hand, HandValue expectedHandValue) => new PokerHand(hand).HandValue.Should().Be(expectedHandValue);
    }
}
