using System.Collections.Generic;
using UnityEngine;

public class DamageEffectFactory
{
    public enum DamageStyle {
        Normal,
        Heal,
        Debries
    }

    private Dictionary<DamageStyle, GameObject> prefabByType = new Dictionary<DamageStyle, GameObject>();

    public DamageEffectFactory(GameObject prefabForDamage, GameObject healEffectPrefab, GameObject debriesEffectPrefab)
    {
        prefabByType[DamageStyle.Normal] = prefabForDamage;
        prefabByType[DamageStyle.Heal] = healEffectPrefab;
        prefabByType[DamageStyle.Debries] = debriesEffectPrefab;
    }

    public DamageEffectScript CreateDamageEffect( int damageAmount, Vector3 position)
    {
        return CreateDamageEffect(damageAmount, position, DamageStyle.Normal);
    }

    public DamageEffectScript CreateDamageEffect(int damageAmount, Vector3 position, DamageStyle style)
    {
        return DamageEffectScript.CreateDamageEffect(prefabByType[style], damageAmount, position);
    }
}
