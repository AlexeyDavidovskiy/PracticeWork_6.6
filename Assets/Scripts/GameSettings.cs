using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName ="GameSettings", menuName ="Installers/GameSettings")]
public class GameSettings : ScriptableObjectInstaller<GameSettings>
{
    [SerializeField] private Player.Settings _playerSettings;
    [SerializeField] private Spawn.Settings _spawnSettings;
    [SerializeField] private Zombie.Settings _zombieSettings;
    [SerializeField] private GameInstaller.Settings _gameInstallerSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(_playerSettings);
        Container.BindInstance(_spawnSettings);
        Container.BindInstance(_zombieSettings);
        Container.BindInstance(_gameInstallerSettings);
    }
}
