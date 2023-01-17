using Assets.Logic;
using UnityEngine;
using Zenject;

public class CoreInstaller : MonoInstaller
{
    public GameObject statsPrefab;
    public GameObject damageEffectPrefab;
    public GameObject healEffectPrefab;
    public GameObject debriesEffectPrefab;

    public override void InstallBindings()
    {
        Container.Bind<StatsScript>().FromComponentInNewPrefab(statsPrefab).AsSingle();
        var def = new DamageEffectFactory(damageEffectPrefab, healEffectPrefab, debriesEffectPrefab);
        Container.Bind<DamageEffectFactory>().FromInstance(def).AsSingle();
        Container.Bind<BoardState>().AsSingle();
    }
}