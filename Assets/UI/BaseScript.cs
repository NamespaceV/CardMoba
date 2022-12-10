using TMPro;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI NameText;

    [SerializeField]
    private TextMeshProUGUI HpText;

    [SerializeField]
    private TextMeshProUGUI SkillsText;

    void Start()
    {
        NameText.text = "Base";
        HpText.text = "Hp 100/100";
        SkillsText.text = "+ 50 G";
    }
}
