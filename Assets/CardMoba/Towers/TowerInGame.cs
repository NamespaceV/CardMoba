using Assets.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class TowerInGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshPro HpText;

    [Inject]
    private BoardState bs;
    public int lane;
    public int pos;

    void Update()
    {
        var u = bs.towers[lane, pos];
        HpText.text = $"{u.hp} / {u.hpMax}";

        HpText.faceColor = bs.selected == u ? Color.red : Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bs.SelectTower(lane, pos);
    }
}
