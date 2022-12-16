using Assets.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class WallScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private TextMeshProUGUI HpText;

    [Inject]
    private BoardState bs;
    private int lane;
    private int pos;

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

    internal void Init(int lane, int pos)
    {
        this.lane = lane;
        this.pos = pos;
    }
}
