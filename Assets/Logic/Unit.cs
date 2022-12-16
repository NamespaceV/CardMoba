using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    internal class Unit : ISelectedObject
    {
        public string Name { get; private set; }
        public List<IActionDescription> Actions => new List<IActionDescription>();

        public int hp = 500;
        public int hpMax = 500;
        private BoardState bs;
        private readonly int lane;
        private readonly int pos;

        public Unit(BoardState boardState, int lane, int pos)
        {
            bs = boardState;
            this.lane = lane;
            this.pos = pos;
            var names = new List<string>() { "Archer", "Mage", "Warior", "Miner" };
            var r = Random.Range(0, names.Count);
            Name = names[r];
        }

        internal void EndTurn()
        {
            bs.enemies[lane, 0].Hit(Random.Range(5, 10));
            bs.enemies[lane, 1].Hit(Random.Range(5, 10));
            bs.enemies[lane, 2].Hit(Random.Range(5, 10));
        }

        internal void Hit(int v)
        {
            hp -= v;
        }
    }
}