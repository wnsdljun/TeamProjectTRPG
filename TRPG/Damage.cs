using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TRPG
{
    internal class Damage
    {
        public Player player;
        public void EnemtAttackDamage(Enemy enemy, int damage)
        {
            Random random = new Random();
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"플레이어는 {Randomdamage}의 피해를 입었다!\n");
            player.Championclass.hp -= Randomdamage;
        }
        public void PlayerAttackDamage(Player player)
        {
            Random random = new Random();
            int Randomdamage = random.Next(damage - (damage / 10), damage + (damage / 10 + 1));
            Console.WriteLine($"{player.PlayerName}이 기본 공격을 사용합니다. (데미지: {Randomdamage})");
            player.Championclass.atk=0;
        }
    }
}
