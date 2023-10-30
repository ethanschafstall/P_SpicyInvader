using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invaders
{
    public class Player
    {
        public int Score { get; set; }
        public string Alias { get; set; }

        public Player(string alias) 
        {
            this.Alias = alias;
        }
        public Player(){}
    }
}
