using Assets.Logic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class InGameUnit : MonoBehaviour, IPointerClickHandler
{
    [Inject]
    private BoardState bs;

    [Inject]
    private DamageEffectFactory def;

    [SerializeField]
    private TextMeshPro NameText;

    [SerializeField]
    private TextMeshPro HpText;

    [SerializeField]
    private TextMeshPro SkillsText;

    public int lane;
    public int pos;
    
    void Start()
    {
        var u = bs.units[lane, pos];
        u.OnTakeDamage += (v) => {
            var randomV = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), -Random.Range(0, 0.01f));
            if (v < 0) {
                def.CreateDamageEffect(-v, transform.position + randomV - new Vector3(0, 0, 0.001f), DamageEffectFactory.DamageStyle.Heal);
            }
            else
            {
                def.CreateDamageEffect(v, transform.position + randomV - new Vector3(0, 0, 0.001f));
            }
        };
    }

    void Update()
    {
        var u = bs.units[lane, pos];

        NameText.text = u.Name;
        HpText.text = $"{u.hp} / {u.hpMax}";
        SkillsText.text = string.Join('\n', u.Actions.Select(s => "- " + s.Name));

        NameText.fontStyle = bs.selected == u ? FontStyles.Bold : FontStyles.Normal;
        NameText.faceColor = bs.selected == u ? Color.red : Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bs.SelectUnit(lane, pos);
    }
}
