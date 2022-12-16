using TMPro;
using UnityEngine;

public class DetailsActionScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextMesh;

    IActionDescription action;

    public void Init(IActionDescription action) {
        this.action = action;
    }

    void Update()
    {
        TextMesh.text = $"{action.Name}";
    }

    public void ExecuteClicked() {
        action.Execute();
    }
}
