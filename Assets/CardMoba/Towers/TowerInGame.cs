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

    [Inject]
    private DamageEffectFactory def;

    public int lane;
    public int pos;

    void Start()
    {
        var u = bs.towers[lane, pos];
        u.OnTakeDamage += (v) => {
            var randomV = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), -Random.Range(0, 0.01f));
            def.CreateDamageEffect(v, transform.position + randomV - new Vector3(0, 0, 0.001f), DamageEffectFactory.DamageStyle.Debries);
        };
    }

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
