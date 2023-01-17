using Assets.Logic.Enemies;
using Assets.Logic.Units;
using System;
using UnityEngine;

namespace Assets.Logic
{
    public class StatsScript : MonoBehaviour
    {
        public EnemySO[] enemyStats;
        public UnitSO[] unitStats;


        internal EnemySO getRandomEnemy()
        {
            return enemyStats[UnityEngine.Random.Range(0, enemyStats.Length)];
        }

        internal UnitSO getRandomUnit()
        {
            return unitStats[UnityEngine.Random.Range(0, unitStats.Length)];
        }
    }
}
