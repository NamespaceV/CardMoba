using UnityEditor;
using UnityEngine;
using Zenject;

public class MainUi : MonoBehaviour
{
    public GameObject TopBarPrefab;
    public GameObject DetailsPrefab;

    public GameObject HomePrefab;
    public GameObject UnitPrefab;
    public GameObject WallPrefab;
    public GameObject EnemyPrefab;

    [Inject]
    DiContainer diContainer;

    private TopBarScript _topBar;
    private DetailsScript _details;
    private HomeScript _home;
    private UnitScript[,] _units  = new UnitScript[3, 3];
    private WallScript[,] _walls = new WallScript[3, 2];
    private EnemyScript[,] _enemies = new EnemyScript[3, 3];

    const int MARGIN = 10;
    const int BASE_WIDTH = 140;
    const int UNIT_WIDTH = 140;
    const int WALL_WIDTH = 50;
    const int TOP_BAR_H = 90;

    void Start()
    {
        _home = diContainer.InstantiatePrefab(HomePrefab, transform).GetComponent<HomeScript>();
        _home.transform.localPosition = new Vector3(MARGIN, -TOP_BAR_H - MARGIN -300, 0);

        for (int lane = 0; lane < 3; ++lane)
        {
            for (int n = 0; n < 3; ++n) {
                //_units[lane, n] = diContainer.InstantiatePrefab(UnitPrefab, transform).GetComponent<UnitScript>();
                //_units[lane, n].transform.localPosition = new Vector3(MARGIN + BASE_WIDTH + MARGIN + n * (UNIT_WIDTH + WALL_WIDTH + 2*MARGIN),
                //    -TOP_BAR_H - MARGIN -lane * 300, 0);
                //_units[lane, n].Init(lane, n);
            }
            for (int n = 0; n < 2; ++n)
            {
                _walls[lane, n] = diContainer.InstantiatePrefab(WallPrefab, transform).GetComponent<WallScript>();
                _walls[lane, n].transform.localPosition = new Vector3(MARGIN + BASE_WIDTH + 2* MARGIN + UNIT_WIDTH + n * (UNIT_WIDTH + WALL_WIDTH + 2 * MARGIN),
                    -TOP_BAR_H - MARGIN -lane * 300, 0);
                _walls[lane, n].Init(lane, n);
            }
            for (int n = 0; n < 3; ++n)
            {
                _enemies[lane, n] = diContainer.InstantiatePrefab(EnemyPrefab, transform).GetComponent<EnemyScript>();
                _enemies[lane, n].transform.localPosition = new Vector3(MARGIN + BASE_WIDTH + MARGIN + 3*(UNIT_WIDTH + WALL_WIDTH + 2* MARGIN) + MARGIN + n * (UNIT_WIDTH + MARGIN),
                    -TOP_BAR_H - MARGIN - lane * 300, 0);
                _enemies[lane, n].Init(lane, n);
            }
        }

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
