using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using System.Linq;

using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using static DamageEffectFactory;

public class EnemyInGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshPro NameText;

    [SerializeField]
    private TextMeshPro HpText;

    [SerializeField]
    private TextMeshPro SkillsText;

    [SerializeField]
    private SpriteRenderer Avatar;

    [Inject]
    private BoardState bs;

    [Inject]
    private DamageEffectFactory def;

    [Inject]
    private StatsScript stats;

    public int lane;
    public int position;

    void Start()
    {
        Enemy e = bs.enemies[lane, position];
        Avatar.sprite = e.template.AvatarSprite;
        e.OnTakeDamage += (v) => {
            var randomV = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), -Random.Range(0.01f, 0.02f));
            var style = v < 0? DamageStyle.Heal : DamageStyle.Normal;
            def.CreateDamageEffect(v, transform.position + randomV - new Vector3(0, 0, 0.001f), style);
            if (e.IsDead() ) { Avatar.sprite = stats.DeadSprite; }
        };
    }

    void Update()
    {
        Enemy e = bs.enemies[lane, position];
        NameText.text = e.Name;
        HpText.text = $"{e.hp} / {e.hpMax}";
        SkillsText.text = string.Join('\n', e.Actions.Select(s => "- " + s.Name));

        NameText.fontStyle = bs.selected == e ? FontStyles.Bold : FontStyles.Normal;
        NameText.faceColor = bs.selected == e ? Color.red : Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.SelectEnemy(lane, position);
    }

}
