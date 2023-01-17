using Assets.Logic;
using UnityEngine;
using Zenject;

public class CoreInstaller : MonoInstaller
{
    public GameObject statsPrefab;
    public override void InstallBindings()
    {
        Container.Bind<StatsScript>().FromComponentInNewPrefab(statsPrefab).AsSingle();
        Container.Bind<BoardState>().AsSingle();
    }
}