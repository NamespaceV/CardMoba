using System;
using UnityEngine;

namespace Assets.Logic.Enemies
{
    [Serializable]
    public class EnemySkillHeal : EnemySkill
    {
        public int heal;

        public EnemySkillHeal()
        {
            Name = "Heal";
        }

        public override void Apply(BoardState bs, Enemy attacker)
        {
            for (int i = 0; i < 3; ++i) {
                if (bs.enemies[attacker.lane, i].CanBeHealed()) {
                    bs.enemies[attacker.lane, i].Heal(heal);
                    return;
                }
            }
        }
    }
}
