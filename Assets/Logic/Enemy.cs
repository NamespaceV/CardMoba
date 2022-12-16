using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    internal class Enemy : ISelectedObject
    {
        public string Name { get; private set; }

        public List<IActionDescription> Actions => new List<IActionDescription>();

        public int hp = 500;
        public int hpMax = 500;

        public Enemy() {
            var names = new List<string>() { "Orc", "Goblin", "Troll" };
            var r = Random.Range(0, names.Count);
            Name = names[r];
        }
    }
}