using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Board
    {
        private readonly Dictionary<Player, int> players;
     
        public Board()
        {
            players = new Dictionary<Player, int>();
        }
        
        public void AddPlayer(Player player)
        {
            players.Add(player, 0);
        }

        public void MovePlayer(Player player, int roll)
        {
            var currenPosition = players[player];

            currenPosition += roll;

            if (currenPosition > 11)
                currenPosition = currenPosition - 12;

            players[player] = currenPosition;

            Console.WriteLine(player.Name + "'s new location is " + currenPosition);
        }

        public int GetPositionOfPlayer(Player player)
        {
            return players[player];
        }
    }
}