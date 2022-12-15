
using System;

namespace Assets.Logic
{
    class BoardState
    {
        public int Gold = 500;
        public int baseHp = 500;
        public int baseHpMax = 500;

        public Tower[,] towers = new Tower[2, 3];
        public Unit[,]  units = new Unit[3, 3];
        public Enemy[,] enemies = new Enemy[3, 3];

        internal void hitBase(int v)
        {
            baseHp -= v;
        }
    }
}
