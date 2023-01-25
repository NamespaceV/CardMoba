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
            for (int i = 2; i >=0;  i--)
            {
                if (bs.units[attacker.lane, i].CanBeHealed()) {
                    bs.units[attacker.lane, i].Heal(heal);
                    return;
                }
            }
        }
    }


}
