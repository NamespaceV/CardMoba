
using System;

namespace Assets.Logic
{
    class BoardState
    {
        public int Gold = 500;

        public ISelectedObject selected;
        public Home home = new Home();
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
            selected = home;
        }

        internal void HitEnemy(int lane, int position, int v)
        {
            enemies[lane,position].hp -= v;
            selected = enemies[lane, position];
        }

        internal void HitUnit(int lane, int position, int v)
        {
            units[lane, position].hp -= v;
            selected = units[lane, position];
        }

        internal void HitTower(int lane, int position, int v)
        {
            towers[lane, position].hp -= v;
            selected = towers[lane, position];
        }

        public void EndTurn()
        {
            ++Turns;
        }
    }
}
