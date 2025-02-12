//
namespace TRPG
{
    using System;

    internal abstract class Champion : IStatus
    {
        public Damage damage = new Damage();
        public string Name { get; private set; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int MaxHp { get; set; }
        public int MaxMp { get; set; }
        public int GrowthHp { get; private set; }
        public int GrowthMp { get; private set; }
        public int GrowthAtk { get; private set; }
        public int GrowthDef { get; private set; }
        public int Championcode { get; private set; }

        //스킬 사용에 필요한 MP값은 똑같다
        public int Q_MANA_COST = 40;
        public int W_MANA_COST = 45;
        public int E_MANA_COST = 80;


        public int SkillLevelQ { get; set; } = 0;
        public int SkillLevelW { get; set; } = 0;
        public int SkillLevelE { get; set; } = 0;

        //각 스킬의 최대레벨 제한
        protected const int MAX_SKILL_LEVEL_Q = 5;
        protected const int MAX_SKILL_LEVEL_W = 5;
        protected const int MAX_SKILL_LEVEL_E = 5;


        public Champion(string name, int hp, int mp, int atk, int def, int growthHp, int growthMp, int growthAtk, int growthDef, int code)
        {
            Name = name;
            this.hp = hp;
            this.mp = mp;
            this.atk = atk;
            this.def = def;
            GrowthHp = growthHp;
            GrowthMp = growthMp;
            GrowthAtk = growthAtk;
            GrowthDef = growthDef;
            Championcode = code;
            MaxHp = hp;
            MaxMp = mp;
        }

        //레벨업 시 능력치 증가
        public void LevelUpAbility()
        {
            hp += GrowthHp;
            mp += GrowthMp;
            atk += GrowthAtk;
            def += GrowthDef;
            MaxHp += GrowthHp;
        }

        //스킬의 최대 레벨을 넘지 않도록 제한
        public void LevelUpSkillQ() => SkillLevelQ = Math.Min(SkillLevelQ + 1, MAX_SKILL_LEVEL_Q);
        public void LevelUpSkillW() => SkillLevelW = Math.Min(SkillLevelW + 1, MAX_SKILL_LEVEL_W);
        public void LevelUpSkillE() => SkillLevelE = Math.Min(SkillLevelE + 1, MAX_SKILL_LEVEL_E);

        //기본공격(하위 클래스에서 오버라이드 가능)
        public virtual void BaseAttack(Enemy enemy)
        {
            damage.PlayerAttackDamage(Name, enemy);
        }

        //각 챔피언마다 고유의 스킬 구현
        public abstract void UseSkill_Q(Enemy enemy, List<Enemy> enemies);
        public abstract void UseSkill_W(Enemy enemy, List<Enemy> enemies);
        public abstract void UseSkill_E(Enemy enemy, List<Enemy> enemies);

        public abstract void DisplaySkillInfo();

        public abstract string skillInfoQ { get;  }
        public abstract string skillInfoQDetail { get;  }
        public abstract string skillInfoW { get;  }
        public abstract string skillInfoWDetail { get;  }
        public abstract string skillInfoE { get;  }
        public abstract string skillInfoEDetail { get;  }
    }



}
