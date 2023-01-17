using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    public class Tower : ISelectedObject
    {
        public int hp = 500;
        public int hpMax = 500;
        public event System.Action<int> OnTakeDamage;

        public Tower(BoardState boardState, int lane, int pos)
        {
            bs = boardState;
            Lane = lane;
            Pos = pos;
        }

        public string Name => "Tower";

        public List<IActionDescription> Actions => new List<IActionDescription>();

        private BoardState bs;
        public int Lane { get; }
        public int Pos { get; }

        internal void EndTurn()
        {
        }

        internal void Hit(int v)
        {
            if (hp == 0) return;
            hp -= v;
            OnTakeDamage?.Invoke(v);
            if (hp < 0)
            {
                hp = 0;
            }
        }

        internal void Upgrade()
        {
            hp += 10;
            hpMax += 10;
        }
    }
}