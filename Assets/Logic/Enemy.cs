using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    internal class Enemy : ISelectedObject
    {
        public string Name { get; private set; }

        public List<IActionDescription> Actions => new List<IActionDescription>();

        public int hp = 500;
        public int hpMax = 500;
        private BoardState bs;
        private readonly int lane;
        private readonly int pos;

        public Enemy(BoardState boardState, int lane, int pos) {
            bs  = boardState;
            this.lane = lane;
            this.pos = pos;
            var names = new List<string>() { "Orc", "Goblin", "Troll" };
            var r = Random.Range(0, names.Count);
            Name = names[r];
        }

        internal void EndTurn()
        {
            if (hp == 0) return;
            bs.units[lane, 2].Hit(Random.Range(5, 10));
            bs.towers[lane, 1].Hit(Random.Range(5, 10));
            bs.units[lane, 1].Hit(Random.Range(5, 10));
            bs.towers[lane, 0].Hit(Random.Range(5, 10));
            bs.units[lane, 0].Hit(Random.Range(5, 10));
            bs.home.Hit(Random.Range(5, 10));
        }

        internal void Hit(int v)
        {
            if (hp == 0) return;
            hp -= v;
            if (hp <= 0)
            {
                hp = 0;
                Name = "Dead " + Name;
            }
        }
    }
}