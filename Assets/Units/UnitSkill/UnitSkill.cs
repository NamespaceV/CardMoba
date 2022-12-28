using Assets.Logic;
using System;

namespace Assets.Units.UnitSkill
{
    [Serializable]
    public abstract class UnitSkill
    {
        public string Name;

        abstract public void Apply(BoardState bs, Unit attacker);
    }


}
