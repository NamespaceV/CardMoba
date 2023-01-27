using Assets.CardMoba.Board;
using Assets.Logic.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    public class Enemy : ISelectedObject, ITargetable
    {
        public string Name { get; private set; }

        public List<IActionDescription> Actions { get; private set; } = new List<IActionDescription>();

        public event System.Action<int> OnTakeDamage;

        public EnemySO template;

        public int hp = 500;
        public int hpMax = 500;
        private BoardState bs;
        public int lane;
        public int pos;

        public Enemy(BoardState boardState, int lane, int pos, EnemySO template) {
            bs  = boardState;
            this.lane = lane;
            this.pos = pos;
            this.template = template;

            Name = template.Name;
            hp = template.Hp;
            hpMax = template.Hp;

            foreach (var s in template.Skills)
            {
                Actions.Add(new SimpleAction() { Name = s.Name, Execute = () => { s.Apply(bs, this); } });
            }
        }

        internal void EndTurn()
        {
            if (IsDead()) return;
            if (Actions.Count == 0) return;
            Actions[Random.Range(0, Actions.Count)].Execute();
        }

        public void Hit(int v)
        {
            if (IsDead()) return;
            hp -= v;
            if (hp <= 0)
            {
                hp = 0;
                Name = "Dead " + Name;
            }
            OnTakeDamage?.Invoke(v);
        }

        internal bool IsDead()
        {
            return hp == 0;
        }

        internal bool CanBeHealed()
        {
            return !IsDead() && hp < int.MaxValue;
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
    }
}