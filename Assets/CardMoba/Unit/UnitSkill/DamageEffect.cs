using Assets.Logic;
using System;
using System.Diagnostics;

namespace Assets.Units.UnitSkill
{
    [Serializable]
    public class DamageEffect : UnitSkill
    {
        public int damage;

        public DamageEffect()
        {
            Name = "Attack";
        }

        public override void Apply (BoardState bs, Unit attacker)
        {
            int targetId = 0;
            while (targetId < 3 && bs.enemies[attacker.lane, targetId].IsDead()) {
                ++targetId;
            }
            if (targetId < 3) {
                bs.enemies[attacker.lane, targetId].Hit(damage);
            }
        }
    }
}
