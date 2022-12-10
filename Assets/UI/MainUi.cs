using UnityEditor;
using UnityEngine;

public class MainUi : MonoBehaviour
{
    public GameObject BasePrefab;
    public GameObject UnitPrefab;
    public GameObject WallPrefab;
    public GameObject EnemyPrefab;

    private Canvas _canvas;
    private GameObject _base;
    private GameObject[,] _units  = new GameObject[3,3];
    private GameObject[,] _walls = new GameObject[3, 2];

    const int MARGIN = 10;
    const int BASE_WIDTH = 140;
    const int UNIT_WIDTH = 140;
    const int WALL_WIDTH = 50;

    private void OnDrawGizmos()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _canvas = transform.parent.GetComponent<Canvas>();

        _base = Instantiate(BasePrefab, transform);
        _base.transform.localPosition = new Vector3(MARGIN, -MARGIN -300, 0);
        for (int row = 0; row < 3; ++row)
        {
            for (int n = 0; n < 3; ++n) {
                _units[row, n] = Instantiate(UnitPrefab, transform);
                _units[row, n].transform.localPosition = new Vector3(MARGIN + BASE_WIDTH + MARGIN + n * (UNIT_WIDTH + WALL_WIDTH + 2*MARGIN), -MARGIN -row * 300, 0);
            }
            for (int n = 0; n < 2; ++n)
            {
                _walls[row, n] = Instantiate(WallPrefab, transform);
                _walls[row, n].transform.localPosition = new Vector3(MARGIN + BASE_WIDTH + 2* MARGIN + UNIT_WIDTH + n * (UNIT_WIDTH + WALL_WIDTH + 2 * MARGIN), -MARGIN -row * 300, 0);
            }
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


    // Update is called once per frame
    void Update()
    {
        
    }
}

[CustomEditor(typeof(MainUi))]
public class MainUiEditor : Editor
{
    public override void OnInspectorGUI()
    {
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
