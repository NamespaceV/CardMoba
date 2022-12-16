using Assets.Logic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class BaseScript : MonoBehaviour, IPointerDownHandler
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
        NameText.text = "Base";
        SkillsText.text = "+ 50 G";
    }

    void Update()
    {
        HpText.text = $"{bs.baseHp} / {bs.baseHp}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.HitBase(Random.Range(1, 5));
    }
}
