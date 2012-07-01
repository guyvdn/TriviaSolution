namespace Trivia
{
    public class Card
    {
        public Card(string category, string question)
        {
            Category = category;
            Question = question;
        }

        public string Category { get; private set; }
        public string Question { get; private set; }
        public int CorrectAnswer { get { return 7; } }
    }
}