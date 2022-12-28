using Assets.Logic;
using System;

namespace Assets.Units.UnitSkill
{
    [Serializable]
    public class HealEffect: UnitSkill
    {
        public int heal;

        public HealEffect()
        {
            Name = "Heal";
        }

        public override void Apply(BoardState bs, Unit attacker)
        {
            int targetId = 2;
            while (!bs.units[attacker.lane, targetId].CanBeHealed() && targetId >=0)
            {
                --targetId;
            }
            if (targetId >= 0)
            {
                bs.units[attacker.lane, targetId].Heal(heal);
            }
        }
    }


}
