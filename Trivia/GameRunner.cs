using System;

namespace Trivia
{
    public class GameRunner
    {
        public static void Main(string[] args)
        {
            var aGame = new Game();
            var rand = new Random();

            aGame.GetAnswerForQuestion = q => rand.Next(9);

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            aGame.Start();

            while (!Game.IsFinished)
            {
                aGame.PlayTurn(rand.Next(5) + 1);
            }
        }
    }
}

