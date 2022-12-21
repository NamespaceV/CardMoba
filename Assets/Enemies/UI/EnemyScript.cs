using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class EnemyScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshProUGUI NameText;

    [SerializeField]
    private TextMeshProUGUI HpText;

    [SerializeField]
    private TextMeshProUGUI SkillsText;

    [Inject]
    private BoardState bs;

    private int lane;
    private int position;

    void Start()
    {
    }

    void Update()
    {
        Enemy e = bs.enemies[lane, position];
        NameText.text = e.Name;
        HpText.text = $"{e.hp} / {e.hpMax}";
        
        NameText.fontStyle = bs.selected == e ? FontStyles.Bold : FontStyles.Normal;
        NameText.faceColor = bs.selected == e ? Color.red : Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.SelectEnemy(lane, position);
    }

    internal void Init(int lane, int position)
    {
        this.lane = lane;
        this.position = position;
    }
}
