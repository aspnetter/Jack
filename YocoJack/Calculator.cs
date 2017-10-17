using System.Collections.Generic;
using System.Linq;

namespace YocoJack
{
    public class Calculator
    {
        public bool GetResult(Game game)
        {
            var cardsA = game.PlayerACards.Select(s => new Card(s)).ToList();
            var scorePlayerA = GetPoints(cardsA);

            if (scorePlayerA > 21)
            {
                return false;
            }

            var cardsB = game.PlayerBCards.Select(s => new Card(s)).ToList();
            var scorePlayerB = GetPoints(cardsB);

            if (scorePlayerB > 21)
            {
                return true;
            }

            if (scorePlayerA != scorePlayerB)
            {
                return scorePlayerA > scorePlayerB;
            }

            var sortedA = cardsA.OrderByDescending(c => c.Score + (int)c.RankType).ToArray();
            var sortedB = cardsB.OrderByDescending(c => c.Score + (int)c.RankType).ToArray();

            for (var i = 0; i < sortedA.Length; i++)
            {
                if (i >= sortedB.Length) break;

                if (sortedA[i].Score > sortedB[i].Score) return true;
                if (sortedA[i].Score < sortedB[i].Score) return false;
            }
            
            if (sortedA[0].Score == 10 && sortedA[0].RankType != sortedB[0].RankType)
            {
                return sortedA[0].Score + (int)sortedA[0].RankType >
                       sortedB[0].Score + (int)sortedB[0].RankType;
            }

            return (int)sortedA[0].Suite > (int)sortedB[0].Suite;
        }

        private int GetPoints(IEnumerable<Card> cards)
        {
            return cards.Sum(card => card.Score);
        }
    }
}
