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
        NameText.text = bs.enemies[lane, position].Name;
        HpText.text = $"{bs.enemies[lane,position].hp} / {bs.enemies[lane, position].hpMax}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.hitEnemy(lane, position, Random.Range(1, 5));
    }

    internal void Init(int lane, int position)
    {
        this.lane = lane;
        this.position = position;
    }
}
