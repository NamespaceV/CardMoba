using Assets.Logic;
using TMPro;
using UnityEngine;
using Zenject;

public class DetailsScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextMesh;

    [SerializeField]
    private GameObject ActionsScrollContent;

    [SerializeField]
    private GameObject ActionDetailPrefab;

    [Inject]
    private BoardState bs;

    [Inject]
    DiContainer diContainer;

    private ISelectedObject lastSelected;

    void Start()
    {
    }

    void Update()
    {
        TextMesh.text = $"Selected: {bs.selected?.Name}";
        if (lastSelected != bs.selected)
        {
            lastSelected = bs.selected;
            ClearDetailActions();
            PopulateDetailActions();
        }
    }

    private void ClearDetailActions()
    {
        foreach (var c in ActionsScrollContent.transform.GetChildren()) Destroy(c);
    }

    private void PopulateDetailActions()
    {
        const int MARGIN = 10;
        if (lastSelected == null) return;
        int y = -MARGIN;
        foreach (var a in lastSelected.Actions)
        {
            var d = diContainer.InstantiatePrefab(ActionDetailPrefab, ActionsScrollContent.transform).GetComponent<DetailsActionScript>();
            d.Init(a);
            d.transform.localPosition = new Vector3(MARGIN, y, 0);
            y -= 110;
        }
    }

    public void CloseClicked() {
        bs.SelectNothing();
    }
}
