using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Player
    {
        public string PlayerName { get; private set; }
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public int Gold { get; private set; }

        public Champion champion { get; private set; }

        public Player(string playername,Champion champion)
        {
            PlayerName = playername;
            this.champion = champion;
            Level = 1;
            Exp = 0;
            Gold = 1500;
        }        
    }

}
