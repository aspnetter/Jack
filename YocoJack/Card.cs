using System;
using System.Collections.Generic;
using System.Linq;

namespace YocoJack
{
    public class Card
    {
        private readonly Dictionary<string, int> _scoreMap = new Dictionary<string, int>()
        {
            { "A", 11 },
            { "J", 10 },
            { "K", 10 },
            { "Q", 10 },
        };

        private readonly string _rawValue;
        public Card(string value)
        {
            _rawValue = value;
        }

        public string Rank => _rawValue.Remove(_rawValue.Length - 1);

        public CardSuite Suite => Enum.Parse<CardSuite>(_rawValue.Substring(_rawValue.Length - 1));

        public CardRankType RankType => int.TryParse(Rank, out int _) ? CardRankType.Number : Enum.Parse<CardRankType>(Rank);

        public int Score
        {
            get
            {
                var parsed = int.TryParse(Rank, out int score);
                return parsed ? score : _scoreMap[Rank];
            }
        }
    }
}
