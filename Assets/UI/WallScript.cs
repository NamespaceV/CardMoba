using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WallScript : MonoBehaviour, IPointerDownHandler
{

    [SerializeField]
    private TextMeshProUGUI HpText;

    private int hp = 100;
    private int hp_max = 100;

    void Start()
    {
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
