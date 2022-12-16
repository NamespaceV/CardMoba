using System;
using System.Collections.Generic;

namespace Assets.Logic
{
    internal class Tower : ISelectedObject
    {
        public int hp = 500;
        public int hpMax = 500;

        public string Name => "Tower";

        public List<IActionDescription> Actions => new List<IActionDescription>();

        internal void Upgrade()
        {
            hp += 10;
            hpMax += 10;
        }
    }
}