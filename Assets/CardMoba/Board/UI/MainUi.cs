using Assets.Units.UnitSkill;
using UnityEditor;
using UnityEngine;
using Zenject;

public class MainUi : MonoBehaviour
{
    public GameObject TopBarPrefab;
    public GameObject DetailsPrefab;
    public GameObject DamagePrefab;

    [Inject]
    DiContainer diContainer;

    private TopBarScript _topBar;
    private DetailsScript _details;

    void Start()
    {
        _topBar = diContainer.InstantiatePrefab(TopBarPrefab, transform).GetComponent<TopBarScript>();

        _details = diContainer.InstantiatePrefab(DetailsPrefab, transform).GetComponent<DetailsScript>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var mScreen = Input.mousePosition;
            mScreen.z = -1 * (Camera.main.transform.position.z + 2);
            var mWord = Camera.main.ScreenToWorldPoint(mScreen);
            DamageEffectScript.CreateDamageEffect(DamagePrefab, Random.Range(10, 50), mWord);
        }
    }

    internal void TestSpawn()
    {
        TestClean();
        Start();
    }

    internal void TestClean()
    {
        foreach (var c in transform.GetChildren())
        {
            DestroyImmediate(c);
        }
    }
}

[CustomEditor(typeof(MainUi))]
public class MainUiEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MainUi myTarget = (MainUi)target;
        if (GUILayout.Button("Test Spawn"))
        {
            myTarget.TestSpawn();
        }
        if (GUILayout.Button("Clean"))
        {
            myTarget.TestClean();
        }
    }
}
