using System;

namespace TRPG
{
    internal class Teemo : Champion
    {
        public Teemo() : base("티모", 615, 334, 54, 24, 104, 25, 3, 5)
        {
        }

        // Q 스킬: 맹독 다트 
        public override void UseSkill_Q()
        {
            if (SkillLevelQ == 0)
            {
                Console.WriteLine("'맹독 다트' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < Q_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '맹독 다트' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= Q_MANA_COST;

            // Q 스킬의 기본 데미지와 공격력 계수 적용
            int[] qBaseDamageValues = { 30, 50, 70, 90, 110 };
            double qScalingCoefficient = 0.5; // 공격력의 50% 추가
            int baseDamage = qBaseDamageValues[Math.Min(SkillLevelQ - 1, qBaseDamageValues.Length - 1)];
            int scalingDamage = (int)(atk * qScalingCoefficient);
            int totalDamage = baseDamage + scalingDamage;

            Console.WriteLine($"{Name}이(가) '맹독 다트' 스킬을 사용합니다!");
            Console.WriteLine($"적에게 {totalDamage}의 피해를 입히고, 3초 동안 독 효과를 적용합니다.");
            Console.WriteLine("독 효과: 매 초마다 추가 피해가 발생합니다.");
        }

        // W 스킬: 실명다트 지만 그냥 강한 공격
        public override void UseSkill_W()
        {
            if (SkillLevelW == 0)
            {
                Console.WriteLine("'실명다트' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < W_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '실명다트' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= W_MANA_COST;

            int[] wBaseDamageValues = { 40, 60, 80, 100, 120 };
            double wScalingCoefficient = 0.4; // 공격력의 40% 추가
            int baseDamage = wBaseDamageValues[Math.Min(SkillLevelW - 1, wBaseDamageValues.Length - 1)];
            int scalingDamage = (int)(atk * wScalingCoefficient);
            int totalDamage = baseDamage + scalingDamage;

            Console.WriteLine($"{Name}이(가) '실명다트' 스킬을 사용합니다!");
            Console.WriteLine($"적에게 {totalDamage}의 피해를 입힙니다.");
        }

        // E 스킬: 유독성 함정 → 사용 시 즉시 광역 피해 적용
        public override void UseSkill_E()
        {
            if (SkillLevelE == 0)
            {
                Console.WriteLine("'유독성 함정' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < E_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '유독성 함정' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= E_MANA_COST;

            int[] eBaseDamageValues = { 80, 110, 140, 170, 200 };
            double eScalingCoefficient = 0.3; // 공격력의 30% 추가
            int baseDamage = eBaseDamageValues[Math.Min(SkillLevelE - 1, eBaseDamageValues.Length - 1)];
            int scalingDamage = (int)(atk * eScalingCoefficient);
            int totalDamage = baseDamage + scalingDamage;

            Console.WriteLine($"{Name}이(가) '유독성 함정' 스킬을 사용합니다!");
            Console.WriteLine($"적들에게 {totalDamage}의 광역 피해를 입힙니다.");
        }
        public override void DisplaySkillInfo()
        {
            Console.WriteLine("===== 티모 스킬 설명 =====");
            Console.WriteLine("Q - 맹독 다트: 단일 대상에게 피해를 입히고, 일정 시간 동안 독 효과를 부여한다.");
            Console.WriteLine("   기본 데미지: 30/50/70/90/110, 공격력 계수: 0.5");
            Console.WriteLine("W - 실명다트: 단일 대상에게 피해를 입힌다.");
            Console.WriteLine("   기본 데미지: 40/60/80/100/120, 공격력 계수: 0.4");
            Console.WriteLine("E - 유독성 함정: 적 전체에게 광역 피해를 입힌다.");
            Console.WriteLine("   기본 데미지: 80/110/140/170/200, 공격력 계수: 0.3");
            Console.WriteLine("===========================");
        }
    }
}
