using Assets.Logic;
using TMPro;
using UnityEngine;
using Zenject;

public class DetailsScript : MonoBehaviour
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
        TextMesh.text = $"Selected: {bs.selected?.Name}";
    }

    public void CloseClicked() {
        bs.selected = null;
    }
}
