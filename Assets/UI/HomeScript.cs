using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class HomeScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshProUGUI NameText;

    [SerializeField]
    private TextMeshProUGUI HpText;

    [SerializeField]
    private TextMeshProUGUI SkillsText;

    [Inject]
    private BoardState bs;

    void Start()
    {
        NameText.text = "Home";
        SkillsText.text = "+ 50 G";
    }

    void Update()
    {
        HpText.text = $"{bs.home.Hp} / {bs.home.HpMax}";

        NameText.fontStyle = bs.selected == bs.home ? FontStyles.Bold : FontStyles.Normal;
        NameText.faceColor = bs.selected == bs.home ? Color.red : Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.HitBase(Random.Range(1, 5));
    }
}
