using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    internal class Tower : ISelectedObject
    {
        public int hp = 500;
        public int hpMax = 500;

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
            hp -= v;
        }

        internal void Upgrade()
        {
            hp += 10;
            hpMax += 10;
        }
    }
}