using System.Collections.Generic;
using PMA.Card;

namespace PMA.Game
{
    public class CompareCard
    {
        public List<CardSO> card { get; private set; } = new List<CardSO>();

        public CompareCard(CardSO card1,CardSO card2)
        {
            card.Add(card1);
            card.Add(card2);
        }
    }
}
