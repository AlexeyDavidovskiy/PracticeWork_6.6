using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "Installers/BulletSettings")]
public class BulletSettingsInstaller : ScriptableObjectInstaller<BulletSettingsInstaller>
{
    [SerializeField] private Bullet.Settings _bulletSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(_bulletSettings);
    }

    [System.Serializable]
    public class BulletSettings : Bullet.Settings { }
}
