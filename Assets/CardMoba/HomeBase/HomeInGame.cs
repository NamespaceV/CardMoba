using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

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

    void Start()
    {
        NameText.text = "Home";
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
