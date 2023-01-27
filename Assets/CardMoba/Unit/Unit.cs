using Assets.CardMoba.Board;
using System.Collections.Generic;
using UnityEngine;

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

        public Units.UnitSO template;

        public Unit(BoardState boardState, int lane, int pos, Units.UnitSO template)
        {
            bs = boardState;
            this.template = template;
            this.lane = lane;
            this.pos = pos;
            Name = template.Name;
            hp = template.Hp;
            hpMax = template.Hp;
            foreach (var s in template.UnitSkillAttackEffects)
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
            if (hp <= 0) {
                hp = 0;
                Name = "Dead " + Name;
            }
            OnTakeDamage?.Invoke(v);
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