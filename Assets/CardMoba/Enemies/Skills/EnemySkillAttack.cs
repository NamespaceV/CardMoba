using System;
using UnityEngine;

namespace Assets.Logic.Enemies
{
    [Serializable]
    public class EnemySkillAttack: EnemySkill
    {
        public int damageMin;
        public int damageMax;

        public override void Apply(BoardState bs, Enemy attacker) {
            bs.GetTragetForEnemy(attacker.lane)
                ?.Hit(UnityEngine.Random.Range(damageMin, damageMax));
        }
    }
}
