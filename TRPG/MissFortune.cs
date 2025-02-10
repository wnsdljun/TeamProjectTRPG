using System;
//
namespace TRPG
{
    internal class MissFortune : Champion
    {
        Enemy enemy;
        public MissFortune() : base("미스 포춘", 640, 300, 53, 25, 103, 40, 3, 4, 3)
        {
        }

        public override void UseSkill_Q()
        {
            if (SkillLevelQ == 0)
            {
                Console.WriteLine("'한 발에 두 놈' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < Q_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '한 발에 두 놈' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= Q_MANA_COST;
            int[] baseDamageValues = { 20, 45, 70, 95, 120 };
            int baseDamage = baseDamageValues[Math.Min(SkillLevelQ - 1, baseDamageValues.Length - 1)];
            // 여기서는 플레이어 레벨 대신 기본 배수를 1로 사용합니다.
            int totalDamage = baseDamage + (int)(atk * 1.0 * 1);
            Console.WriteLine($"{Name}이(가) '한 발에 두 놈' 스킬을 사용합니다!");
            Console.WriteLine($"첫 번째 적에게 {totalDamage} 데미지를 입힙니다.");

            // 예시로 첫 번째 적 처치 시 두 번째 적에게 추가 피해
            bool firstTargetDies = true;
            if (firstTargetDies)
            {
                Console.WriteLine("첫 번째 적이 처치되었습니다! 두 번째 적에게 추가 데미지를 입힙니다!");
                Console.WriteLine($"두 번째 적에게 {totalDamage * 2} 데미지를 입힙니다.");
            }
        }

        public override void UseSkill_W()
        {
            if (SkillLevelW == 0)
            {
                Console.WriteLine("'사랑의 한 방' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < W_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '사랑의 한 방' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= W_MANA_COST;
            double[] attackBoostRatios = { 0.6, 0.7, 0.8, 0.9, 1.0 };
            double attackBoost = attackBoostRatios[Math.Min(SkillLevelW - 1, attackBoostRatios.Length - 1)] * atk * 1;
            int originalAtk = atk;
            atk += (int)attackBoost;
            Console.WriteLine($"{Name}이(가) '사랑의 한 방' 스킬을 사용합니다!");
            Console.WriteLine($"공격력이 {attackBoost} 만큼 증가하고 즉시 기본 공격을 수행합니다.");
            BaseAttack(enemy);
            atk = originalAtk;
            Console.WriteLine("공격력이 원래 상태로 돌아갑니다.");
        }

        public override void UseSkill_E()
        {
            if (SkillLevelE == 0)
            {
                Console.WriteLine("'총알은 비를 타고' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < E_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '총알은 비를 타고' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= E_MANA_COST;
            int[] baseDamageValues = { 70, 80, 90, 100, 110, 120 };
            int baseDamage = baseDamageValues[Math.Min(SkillLevelE - 1, baseDamageValues.Length - 1)];
            int totalDamage = baseDamage * 1;
            Console.WriteLine($"{Name}이(가) '총알은 비를 타고' 스킬을 사용합니다!");
            Console.WriteLine($"적 전체에게 {totalDamage}의 광역 데미지를 입힙니다.");
        }
        public override void DisplaySkillInfo()
        {
            Console.WriteLine("===== 미스 포춘 스킬 설명 =====");
            Console.WriteLine("Q - 한 발에 두 놈: 두 대상에게 순차적으로 피해를 입힌다.");
            Console.WriteLine("   기본 데미지: 40/60/80/100/120, 공격력 계수: 0.5");
            Console.WriteLine("W - 사랑의 한 방: 단일 대상에게 피해를 입힌다.");
            Console.WriteLine("   기본 데미지: 30/45/60/75/90, 공격력 계수: 0.4");
            Console.WriteLine("E - 총알은 비를 타고: 적 전체에게 광역 피해를 입힌다.");
            Console.WriteLine("   기본 데미지: 70/95/120/145/170, 공격력 계수: 0.3");
            Console.WriteLine("=================================");
        }
    }
}




