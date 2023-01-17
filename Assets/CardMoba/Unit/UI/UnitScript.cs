using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UnitScript : MonoBehaviour, IPointerDownHandler
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
    private int pos;

    void Start()
    {
    }

    void Update()
    {
        var u = bs.units[lane, pos];

        NameText.text = u.Name;
        HpText.text = $"{u.hp} / {u.hpMax}";

        NameText.fontStyle = bs.selected == u ? FontStyles.Bold : FontStyles.Normal;
        NameText.faceColor = bs.selected == u ? Color.red : Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.SelectUnit(lane, pos);
    }

    internal void Init(int lane, int pos)
    {
        this.lane = lane;
        this.pos = pos;
    }
}
