using Assets.Logic;
using UnityEngine;
using Zenject;

public class CoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BoardState>().AsSingle();
    }
}