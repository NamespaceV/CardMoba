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
            bs.GetTragetForUnit(attacker.lane)?.Hit(damage);
        }
    }
}
