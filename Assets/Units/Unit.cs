using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    internal class Unit : ISelectedObject
    {
        public string Name { get; private set; }
        public List<IActionDescription> Actions { get; private set; } = new List<IActionDescription>();

        public int hp = 500;
        public int hpMax = 500;
        private BoardState bs;
        private readonly int lane;
        private readonly int pos;

        public Unit(BoardState boardState, int lane, int pos, Units.UnitSO data)
        {
            bs = boardState;
            this.lane = lane;
            this.pos = pos;
            Name = data.Name;
            hp = data.Hp;
            hpMax = data.Hp;
            foreach (var s in data.Skills)
            {
                Actions.Add(new SimpleAction() { Name = s.Name, Execute = () => { } });
            }
        }

        internal void EndTurn()
        {
            if (hp == 0) return;
            bs.enemies[lane, 0].Hit(Random.Range(5, 10));
            bs.enemies[lane, 1].Hit(Random.Range(5, 10));
            bs.enemies[lane, 2].Hit(Random.Range(5, 10));
        }

        internal void Hit(int v)
        {
            if (hp == 0) return;
            hp -= v;
            if (hp <= 0) {
                hp = 0;
                Name = "Dead " + Name;
            }
        }
    }
}