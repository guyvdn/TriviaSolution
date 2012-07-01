namespace Trivia
{
    public class CardFactory
    {
        public Card CreateCard(string category, string question)
        {
            return new Card(category, question);
        }
    }
}