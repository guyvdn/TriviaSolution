using System;

namespace Trivia
{
    public class Player
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        public Player(string playerName)
        {
            Name = playerName;
        }

        public void AddPoint()
        {
            Points++;

            Console.WriteLine(Name + " now has " + Points + " Gold Coins.");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}