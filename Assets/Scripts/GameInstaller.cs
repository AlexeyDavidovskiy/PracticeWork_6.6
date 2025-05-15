using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject]
    private Settings _settings;

    public override void InstallBindings()
    {
        Container.BindFactory<Zombie, Zombie.Factory>()
            .FromComponentInNewPrefab(_settings.ZombiePredab)
            .WithGameObjectName("Zombie")
            .UnderTransformGroup("Zombies");

        Container.Bind<Player>().FromComponentInHierarchy().AsSingle().NonLazy();
    }

    [System.Serializable]
    public class Settings 
    {
        public GameObject ZombiePredab;
    }
}
