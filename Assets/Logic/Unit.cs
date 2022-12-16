using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic
{
    internal class Unit : ISelectedObject
    {
        public string Name { get; private set; }
        public int hp = 500;
        public int hpMax = 500;

        public Unit() {
            var names = new List<string>() { "Archer", "Mage", "Warior", "Miner" };
            var r = Random.Range(0, names.Count);
            Name = names[r];
        }
    }
}