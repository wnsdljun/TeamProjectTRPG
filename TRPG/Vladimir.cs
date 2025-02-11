//
namespace TRPG
{
    internal class Vladimir : Champion
    {

        public Vladimir() : base("블라디미르", 607, 320, 55, 27, 110, 30, 3, 5, 1)
        {
        }

        // Q 스킬: 수혈
        // - 적에게 데미지를 주고, 그 데미지의 50%만큼 자신의 체력을 회복합니다.
        public override void UseSkill_Q(Enemy enemy)
        {
            if (SkillLevelQ == 0)
            {
                Console.WriteLine("'수혈' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < Q_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '수혈' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= Q_MANA_COST;

            // Q 스킬 기본 데미지 배열: {80, 100, 120, 140, 160}
            // 공격력의 60% 추가
            int[] qBaseDamageValues = { 80, 100, 120, 140, 160 };
            double qScalingCoefficient = 0.6;
            int baseDamage = qBaseDamageValues[Math.Min(SkillLevelQ - 1, qBaseDamageValues.Length - 1)];
            int scalingDamage = (int)(atk * qScalingCoefficient);
            int totalDamage = baseDamage + scalingDamage;

            // 회복량은 입힌 피해량의 50%
            int healAmount = (int)(totalDamage * 0.5);

            hp += healAmount;

            Console.WriteLine($"{Name}이(가) '수혈' 스킬을 사용합니다!");
            damage.PlayerSkillDamage(totalDamage, enemy);
            Console.WriteLine($"자신은 {healAmount}의 체력을 회복합니다.");
        }

        // W 스킬: 혈사병
        // - 적 전체에게 데미지를 입히고, 입힌 데미지의 40%만큼 자신의 체력을 회복합니다.
        public override void UseSkill_W(Enemy enemy)
        {
            if (SkillLevelW == 0)
            {
                Console.WriteLine("'혈사병' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < W_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '혈사병' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= W_MANA_COST;

            // W 스킬 기본 데미지 배열: {50, 75, 100, 125, 150}
            // 공격력의 70% 추가 (계수 0.7)
            int[] wBaseDamageValues = { 50, 75, 100, 125, 150 };
            double wScalingCoefficient = 0.7;
            int baseDamage = wBaseDamageValues[Math.Min(SkillLevelW - 1, wBaseDamageValues.Length - 1)];
            int scalingDamage = (int)(atk * wScalingCoefficient);
            int totalDamage = baseDamage + scalingDamage;

            // 회복량은 입힌 피해의 40%
            int healAmount = (int)(totalDamage * 0.4);

            hp += healAmount;

            Console.WriteLine($"{Name}이(가) '혈사병' 스킬을 사용합니다!");
            damage.PlayerAllSkillDamage(totalDamage);
            Console.WriteLine($"자신은 {healAmount}의 체력을 회복합니다.");
        }

        // E 스킬: 선혈의 파도
        // - 적 전체에게 광역 피해를 입힙니다.
        public override void UseSkill_E(Enemy enemy)
        {
            if (SkillLevelE == 0)
            {
                Console.WriteLine("'선혈의 파도' 스킬을 아직 배우지 않았습니다.");
                return;
            }
            if (mp < E_MANA_COST)
            {
                Console.WriteLine("MP가 부족하여 '선혈의 파도' 스킬을 사용할 수 없습니다.");
                return;
            }
            mp -= E_MANA_COST;

            // E 스킬 기본 데미지 배열: {60, 90, 120, 150, 180}
            // 공격력의 80% 추가
            int[] eBaseDamageValues = { 60, 90, 120, 150, 180 };
            double eScalingCoefficient = 0.8;
            int baseDamage = eBaseDamageValues[Math.Min(SkillLevelE - 1, eBaseDamageValues.Length - 1)];
            int scalingDamage = (int)(atk * eScalingCoefficient);
            int totalDamage = baseDamage + scalingDamage;

            Console.WriteLine($"{Name}이(가) '선혈의 파도' 스킬을 사용합니다!");
            damage.PlayerAllSkillDamage(totalDamage);
        }
        public override void DisplaySkillInfo()
        {
            Console.WriteLine("===== 블라디미르 스킬 설명 =====");
            Console.WriteLine("Q - 수혈: 적에게 데미지를 주고, 입힌 데미지의 50%만큼 체력을 회복한다.");
            Console.WriteLine("   기본 데미지: 80/100/120/140/160, 공격력 계수: 0.6");
            Console.WriteLine("W - 혈사병: 적 전체에게 데미지를 입히고, 입힌 데미지의 40%만큼 체력을 회복한다.");
            Console.WriteLine("   기본 데미지: 50/75/100/125/150, 공격력 계수: 0.7");
            Console.WriteLine("E - 선혈의 파도: 적 전체에게 광역 피해를 입힌다.");
            Console.WriteLine("   기본 데미지: 60/90/120/150/180, 공격력 계수: 0.8");
            Console.WriteLine("================================");
        }

        public override string skillInfoQ => "Q - 수혈: 적에게 데미지를 주고, 입힌 데미지의 50%만큼 체력을 회복한다.";
        public override string skillInfoQDetail => "   기본 데미지: 80/100/120/140/160, 공격력 계수: 0.6";
        public override string skillInfoW => "W - 혈사병: 적 전체에게 데미지를 입히고, 입힌 데미지의 40%만큼 체력을 회복한다.";
        public override string skillInfoWDetail => "   기본 데미지: 50/75/100/125/150, 공격력 계수: 0.7";
        public override string skillInfoE => "E - 선혈의 파도: 적 전체에게 광역 피해를 입힌다.";
        public override string skillInfoEDetail => "   기본 데미지: 60/90/120/150/180, 공격력 계수: 0.8";
    }
}
