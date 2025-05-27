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

        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<ZombieDiedSignal>();
        Container.DeclareSignal<PlayerDiedSignal>();

        Container.BindFactory<Bullet, Bullet.BulletFactory>()
            .FromComponentInNewPrefab(_settings.BulletPrefab)
            .UnderTransformGroup("Bullets");

        Container.Bind<Score>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Spawn>().FromComponentInHierarchy().AsSingle().NonLazy();
    }

    [System.Serializable]
    public class Settings 
    {
        public GameObject ZombiePredab;
        public GameObject BulletPrefab;
    }
}
