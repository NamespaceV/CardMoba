using Assets.CardMoba.Board;
using System;
using System.Collections.Generic;

namespace Assets.Logic
{
    public class Unit : ISelectedObject, ITargetable
    {
        public string Name { get; private set; }
        public List<IActionDescription> Actions { get; private set; } = new List<IActionDescription>();
        public event System.Action<int> OnTakeDamage;


        public int hp = 500;
        public int hpMax = 500;
        private BoardState bs;
        public int lane { get; private set; }
        public int pos { get; private set; }

        public Unit(BoardState boardState, int lane, int pos, Units.UnitSO data)
        {
            bs = boardState;
            this.lane = lane;
            this.pos = pos;
            Name = data.Name;
            hp = data.Hp;
            hpMax = data.Hp;
            foreach (var s in data.UnitSkillAttackEffects)
            {
                Actions.Add(new SimpleAction() { Name = s.Name, Execute = () => { s.Apply(bs, this); } });
            }
        }

        internal void EndTurn()
        {
            if (IsDead()) return;
            //bs.enemies[lane, 0].Hit(Random.Range(5, 10));
            //bs.enemies[lane, 1].Hit(Random.Range(5, 10));
            //bs.enemies[lane, 2].Hit(Random.Range(5, 10));
        }

        public void Hit(int v)
        {
            if (IsDead()) return;
            hp -= v;
            OnTakeDamage?.Invoke(v);
            if (hp <= 0) {
                hp = 0;
                Name = "Dead " + Name;
            }
        }
        internal void Heal(int v)
        {
            if (IsDead()) return;
            hp += v;
            OnTakeDamage?.Invoke(-v);
            if (hp >= hpMax)
            {
                hp = hpMax;
            }
        }
        internal bool IsDead() {
            return hp == 0;
        }

        internal bool CanBeHealed()
        {
            return IsDead() == false && hp < hpMax;
        }
    }
}