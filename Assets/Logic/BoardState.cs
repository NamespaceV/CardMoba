
using System;

namespace Assets.Logic
{
    class BoardState
    {
        public int Gold = 500;
        public int baseHp = 500;
        public int baseHpMax = 500;

        public Tower[,] towers = new Tower[3, 2];
        public Unit[,]  units = new Unit[3, 3];
        public Enemy[,] enemies = new Enemy[3, 3];
        public int Turns { get; private set; }

        public BoardState()
        {
            for (var l = 0; l < 3; ++l) {
                for (int i = 0; i < 2; ++i) {
                    towers[l, i] = new Tower();
                }
                for (int i = 0; i < 3; ++i)
                {
                    units[l, i] = new Unit();
                }
                for (int i = 0; i < 3; ++i)
                {
                    enemies[l, i] = new Enemy();
                }
            }
        }

        internal void HitBase(int v)
        {
            baseHp -= v;
        }

        internal void HitEnemy(int lane, int position, int v)
        {
            enemies[lane,position].hp -= v;
        }

        internal void HitUnit(int lane, int position, int v)
        {
            units[lane, position].hp -= v;
        }

        internal void HitTower(int lane, int position, int v)
        {
            towers[lane, position].hp -= v;
        }

        public void EndTurn()
        {
            ++Turns;
        }
    }
}
