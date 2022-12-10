using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshProUGUI NameText;

    [SerializeField]
    private TextMeshProUGUI HpText;

    [SerializeField]
    private TextMeshProUGUI SkillsText;

    private int hp = 100;
    private int hp_max = 100;

    void Start()
    {
        NameText.text = "Base";
        SkillsText.text = "+ 50 G";
    }

    void Update()
    {
        HpText.text = $"{hp} / {hp_max}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        hp -= Random.Range(1, 5);
    }
}
