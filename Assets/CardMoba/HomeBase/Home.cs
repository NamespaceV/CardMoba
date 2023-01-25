
using Assets.CardMoba.Board;
using System;
using System.Collections.Generic;

namespace Assets.Logic
{
    public class Home : ISelectedObject, ITargetable
    {
        public string Name => "Base";
        public List<IActionDescription> Actions { get; private set; } = new List<IActionDescription>();
        private int actionsAdded;
        public event System.Action<int> OnTakeDamage;


        public Home(BoardState boardState) {
            bs = boardState;
            Actions.Add(new SimpleAction { Name = "100G -> Upgrade gatherers", Execute = () => {
                if (bs.Gold < 100) return;
                bs.Pay(100);
                Gatherers += 10;
            }});
            Actions.Add(new SimpleAction { Name = "100G -> Upgrade walls", Execute = () => {
                if (bs.Gold < 100) return;
                bs.Pay(100);
                foreach (var t in boardState.towers) t.Upgrade();
            }});
        }

        private void AddAction()
        {
            ++actionsAdded;
            Actions.Add(new SimpleAction { Name = "Add Action "+ actionsAdded, Execute = () => { AddAction(); } });
        }

        internal void EndTurn()
        {
            bs.Gold += Gatherers;
        }

        public void Hit(int v)
        {
            if (Hp == 0) return;
            Hp -= v;
            OnTakeDamage?.Invoke(v);
            if (Hp <= 0) {
                Hp = 0;
            }
        }

        public int Hp = 1500;
        public int HpMax = 1500;
        public int Gatherers = 50;
        private BoardState bs;
    }
}
