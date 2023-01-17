using UnityEngine;

namespace Assets.Logic.Enemies
{
    [CreateAssetMenu(fileName = "EnemySkill", menuName = "SO/EnemySkillSO", order = 1)]
    public class EnemySkillSO : ScriptableObject
    {
        public string Name;
    }
}
