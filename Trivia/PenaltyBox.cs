using System.Collections.Generic;

namespace Trivia
{
    public class PenaltyBox
    {
        private readonly List<Player> players;

        public PenaltyBox()
        {
            players = new List<Player>();
        }

        public bool HasPlayer(Player player)
        {
            return players.Contains(player);
        }

        public bool CanPlayerGetOut(int roll)
        {
            return roll % 2 == 0;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }
    }
}