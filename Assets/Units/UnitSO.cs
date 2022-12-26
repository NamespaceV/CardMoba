using UnityEngine;

namespace Assets.Logic.Units
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "SO/UnitSO", order = 1)]
    public class UnitSO : ScriptableObject
    {
        public int Cost;
        public string Name;
        public int Hp;
        public UnitSkillSO[] Skills;
    }
}
