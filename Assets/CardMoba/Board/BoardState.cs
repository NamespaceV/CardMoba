using Assets.CardMoba.Board;
using Assets.Logic.Enemies;
using System;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;

namespace Assets.Logic
{
    public class BoardState
    {
        public int Gold = 500;

        public ISelectedObject selected;
        public Home home;
        public Tower[,] towers = new Tower[3, 2];
        public Unit[,]  units = new Unit[3, 3];
        public Enemy[,] enemies = new Enemy[3, 3];
        public int Turns { get; private set; }
        public StatsScript stats;

        public BoardState(StatsScript stats)
        {
            this.stats = stats;
            home = new Home(this);
            for (var l = 0; l < 3; ++l) {
                for (int i = 0; i < 2; ++i) {
                    towers[l, i] = new Tower(this, l, i);
                }
                for (int i = 0; i < 3; ++i)
                {
                    units[l, i] = new Unit(this, l, i, stats.getRandomUnit());
                }
                for (int i = 0; i < 3; ++i)
                {
                    enemies[l, i] = new Enemy(this, l, i, stats.getRandomEnemy());
                }
            }
        }

        internal void SelectBase()
        {
            selected = home;
        }

        internal void SelectEnemy(int lane, int position)
        {
            selected = enemies[lane, position];
        }

        internal void SelectUnit(int lane, int position)
        {
            selected = units[lane, position];
        }

        internal void SelectTower(int lane, int position)
        {
            selected = towers[lane, position];
        }

        public ITargetable GetTragetForUnit(int lane) {
            int targetId = 0;
            while (targetId < 3 && enemies[lane, targetId].IsDead())
            {
                ++targetId;
            }
            if (targetId < 3)
            {
                return enemies[lane, targetId];
            }
            return null;
        }

        internal void SelectNothing()
        {
            selected = null;
        }

        public void EndTurn()
        {
            ++Turns;
            home.EndTurn();

            for (var l = 0; l < 3; ++l)
            {
                for (int i = 0; i < 3; ++i)
                {
                    units[l, i].EndTurn();
                }
            }
            for (var l = 0; l < 3; ++l)
            {
                for (int i = 0; i < 2; ++i)
                {
                    towers[l, i].EndTurn();
                }
            }
            for (var l = 0; l < 3; ++l)
            {
                for (int i = 0; i < 3; ++i)
                {
                    enemies[l, i].EndTurn();
                }
            }
        }

        internal void Pay(int g)
        {
            Gold -= g;
        }
    }
}
