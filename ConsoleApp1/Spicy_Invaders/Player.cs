using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    /// <summary>
    /// Class for the player (User) playing the game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Players score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Players Alias
        /// </summary>
        public string Alias { get; set; }

        public Player(string alias)
        {
            this.Alias = alias;
        }
        public Player() { }
    }
}
