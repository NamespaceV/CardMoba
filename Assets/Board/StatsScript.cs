using Assets.Logic.Enemies;
using System;
using UnityEngine;

namespace Assets.Logic
{
    class StatsScript : MonoBehaviour
    {
        public EnemySO[] enemyStats;

        internal EnemySO getRandomEnemy()
        {
            return enemyStats[UnityEngine.Random.Range(0, enemyStats.Length)];
        }
    }
}
