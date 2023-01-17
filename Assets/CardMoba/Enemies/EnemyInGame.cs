using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using System.Linq;

using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class EnemyInGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshPro NameText;

    [SerializeField]
    private TextMeshPro HpText;

    [SerializeField]
    private TextMeshPro SkillsText;

    [Inject]
    private BoardState bs;

    public int lane;
    public int position;

    void Start()
    {
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
