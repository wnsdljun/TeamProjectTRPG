using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Champion : IStatus
    {
        public string Name { get; }  
        public int hp { get; set; }
        public int mp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }

        public Champion(string name, int hp, int mp, int atk, int def)
        {
            Name = name;
            this.hp = hp;
            this.mp = mp;
            this.atk = atk;
            this.def = def;
        }

        public Champion(Champion champion)
        {
            Name = champion.Name;
            this.hp =champion.hp;
            this.mp = champion.mp;
            this.atk = champion.atk;
            this.def = champion.def;
        }




    }

}
