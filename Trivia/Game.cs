using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Game
    {
        public Func<string, int> GetAnswerForQuestion = q => 0;

        private const int NumberOfQuestionsPerCategory = 50;

        private readonly Board board;
        private readonly Queue<Player> players;
        private readonly PenaltyBox penaltyBox;
        private readonly CardDeck cardDeck;
        private readonly CategoryProvider categoryProvider;

        private Player currentPlayer;

        public Game()
        {
            players = new Queue<Player>();
            board = new Board();
            penaltyBox = new PenaltyBox();
            cardDeck = new CardDeck(NumberOfQuestionsPerCategory);
            categoryProvider = new CategoryProvider();
        }

        public void AddPlayer(String playerName)
        {
            var player = new Player(playerName);
            players.Enqueue(player);
            board.AddPlayer(player);

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
        }

        private bool IsPlayable()
        {
            return (NumberOfPlayers() >= 2);
        }

        private int NumberOfPlayers()
        {
            return players.Count;
        }

        public void PlayTurn(int roll)
        {
            Console.WriteLine(currentPlayer + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (PlayerIsInPenaltyBox() && !PlayerGetsOutOfPenaltyBox(roll))
                return;

            board.MovePlayer(currentPlayer, roll);

            AskQuestion(categoryProvider.GetCategoryForPosition(board.GetPositionOfPlayer(currentPlayer)));
        }

        private bool PlayerIsInPenaltyBox()
        {
            return penaltyBox.HasPlayer(currentPlayer);
        }

        private bool PlayerGetsOutOfPenaltyBox(int roll)
        {
            if (!penaltyBox.CanPlayerGetOut(roll))
            {
                Console.WriteLine(currentPlayer + " is not getting out of the penalty box");
                return false;
            }

            penaltyBox.RemovePlayer(currentPlayer);
            Console.WriteLine(currentPlayer + " is getting out of the penalty box");
            return true;
        }

        public static bool IsFinished
        {
            get;
            private set;
        }

        private void AskQuestion(string category)
        {
            Console.WriteLine("The category is " + category);
            var card = cardDeck.GetNextCardForCategory(category);

            if (GetAnswerForQuestion(card.Question) == card.CorrectAnswer)
                PlayerGaveACorrectAnswer();
            else
                PlayerGaveAWrongAnswer();
        }

        private void PlayerGaveACorrectAnswer()
        {
            Console.WriteLine("Answer was correct!!!!");

            currentPlayer.AddPoint();

            IsFinished = DidPlayerWin();

            MoveTurnToNextPlayer();
        }

        private void MoveTurnToNextPlayer()
        {
            players.Enqueue(currentPlayer);
            currentPlayer = players.Dequeue();
        }

        private void PlayerGaveAWrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(currentPlayer.Name + " was sent to the penalty box");

            penaltyBox.AddPlayer(currentPlayer);

            MoveTurnToNextPlayer();
        }

        private bool DidPlayerWin()
        {
            return currentPlayer.Points == 6;
        }

        public void Start()
        {
            if (!IsPlayable())
            {
                Console.WriteLine("Game cannot be started");
                IsFinished = true;
                return;
            }

            currentPlayer = players.Dequeue();
        }
    }
}
