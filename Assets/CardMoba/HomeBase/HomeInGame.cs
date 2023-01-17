using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using static UnityEditor.PlayerSettings;

public class HomeInGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshPro NameText;

    [SerializeField]
    private TextMeshPro HpText;

    [SerializeField]
    private TextMeshPro SkillsText;

    [Inject]
    private BoardState bs;

    [Inject]
    private DamageEffectFactory def;

    void Start()
    {
        NameText.text = "Home";

        bs.home.OnTakeDamage += (v) => {
            var randomV = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), -Random.Range(0, 0.01f));
            def.CreateDamageEffect(v, transform.position + randomV - new Vector3(0, 0, 0.001f), DamageEffectFactory.DamageStyle.Debries);
        };
    }
    void Update()
    {
        var home = bs.home;
        HpText.text = $"{home.Hp} / {home.HpMax}";
        SkillsText.text = $"+ {home.Gatherers} G";

        NameText.fontStyle = bs.selected == bs.home ? FontStyles.Bold : FontStyles.Normal;
        NameText.faceColor = bs.selected == bs.home ? Color.red : Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.SelectBase();
    }
}
