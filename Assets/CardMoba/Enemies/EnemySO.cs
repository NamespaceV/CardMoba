using Assets.Units.UnitSkill;
using System;
using UnityEngine;

namespace Assets.Logic.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "SO/EnemySO", order = 1)]
    public class EnemySO : ScriptableObject
    {
        public string Name;
        public int Hp;

        public Sprite AvatarSprite;

        [SerializeReference, SubclassSelector]
        public EnemySkill[] Skills = Array.Empty<EnemySkill>();
    }
}
