using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour, IPointerDownHandler
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
        var names = new List<string>() { "Orc", "Goblin", "Troll" };
        var r = Random.Range(0, names.Count);
        NameText.text = names[r];
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
