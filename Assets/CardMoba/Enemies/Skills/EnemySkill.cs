using System;
using UnityEngine;

namespace Assets.Logic.Enemies
{
    [Serializable]
    public abstract class EnemySkill
    {
        public string Name;

        public abstract void Apply(BoardState bs, Enemy attacker);
    }
}
