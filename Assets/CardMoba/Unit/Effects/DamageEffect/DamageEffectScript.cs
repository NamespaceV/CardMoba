using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageEffectScript : MonoBehaviour
{
    public TextMeshPro dmgTextMesh;

    public static DamageEffectScript CreateDamageEffect(GameObject prefabForDamage, int damageAmount, Vector3 position)
    {
        var go = Instantiate(prefabForDamage, position, Quaternion.identity, null);
        var r = go.GetComponent<DamageEffectScript>();
        r.dmgTextMesh.text = damageAmount.ToString();
        return r;
    }

    void Start()
    {
        transform.localScale = 0.2f * Vector3.one;
        transform.DOScale(0.5f, 0.5f).Play().OnComplete(() => Destroy(gameObject));
    }
}
