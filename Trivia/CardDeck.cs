using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class CardDeck
    {
        private readonly List<Card> cards;

        public CardDeck(int numberOfQuestionsPerCategory)
        {
            var cardFactory = new CardFactory();

            cards = new List<Card>();

            numberOfQuestionsPerCategory.Times(i =>
                         {
                             cards.Add(cardFactory.CreateCard("Pop", "Pop Question " + i));
                             cards.Add(cardFactory.CreateCard("Science", "Science Question " + i));
                             cards.Add(cardFactory.CreateCard("Sports", "Sports Question " + i));
                             cards.Add(cardFactory.CreateCard("Rock", "Rock Question" + i));
                         });
        }

        public Card GetNextCardForCategory(string category)
        {
            var card = cards.First(q => q.Category == category);
            cards.Remove(card);
            return card;
        }
    }
}