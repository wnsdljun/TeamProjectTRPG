using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    internal class Champion : IStatus
    {
        public string Name { get; private set; }  
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

        public static Champion missfortune = new Champion("미스 포춘", 120, 100, 100, 50);

        public static Champion Teemo = new Champion("티모", 110, 120, 110, 40);

        public static Champion Vladimir = new Champion("블라디미르", 140, 100, 40, 60);




    }

}
