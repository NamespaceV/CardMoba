using Assets.Logic;
using TMPro;
using UnityEngine;
using Zenject;

public class TopBarScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextMesh;

    [Inject]
    private BoardState bs;

    void Start()
    {
        
    }

    void Update()
    {
        TextMesh.text = $"Turn: {bs.Turns} \t Gold: {bs.Gold}";
    }

    public void EndTurnClicked() {
        bs.EndTurn();
    }
}
