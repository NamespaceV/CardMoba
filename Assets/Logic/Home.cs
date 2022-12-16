
using System;
using System.Collections.Generic;

namespace Assets.Logic
{
    class Home : ISelectedObject
    {
        public string Name => "Base";
        public List<IActionDescription> Actions { get; private set; } = new List<IActionDescription>();
        private int actionsAdded;

        public Home(BoardState boardState) {
            bs = boardState;
            Actions.Add(new SimpleAction { Name = "Upgrade gatherers", Execute = () => Gatherers += 10 });
            Actions.Add(new SimpleAction { Name = "Upgrade walls", Execute = () => {
                    foreach (var t in boardState.towers) t.Upgrade();
                }
            });
            Actions.Add(new SimpleAction { Name = "Add Action", Execute = () => { AddAction(); } }) ;
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

        internal void Hit(int v)
        {
            Hp -= v;
        }

        public int Hp = 500;
        public int HpMax = 500;
        public int Gatherers = 50;
        private BoardState bs;
    }
}
