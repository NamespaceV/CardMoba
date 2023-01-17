using UnityEditor;
using UnityEngine;
using Zenject;

public class MainUi : MonoBehaviour
{
    public GameObject TopBarPrefab;
    public GameObject DetailsPrefab;

    [Inject]
    DiContainer diContainer;

    private TopBarScript _topBar;
    private DetailsScript _details;

    void Start()
    {
        _topBar = diContainer.InstantiatePrefab(TopBarPrefab, transform).GetComponent<TopBarScript>();

        _details = diContainer.InstantiatePrefab(DetailsPrefab, transform).GetComponent<DetailsScript>();
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
