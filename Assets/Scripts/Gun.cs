using UnityEngine;
using Zenject;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    private Bullet.BulletFactory _bulletFactory;
    private Bullet.Settings _bulletSettings;
    private PlayerInputHandler _playerInputHandler;
    private Player _player;
    private bool _canShoot = true;

    [Inject]
    public void Construct(Bullet.BulletFactory bulletFactory, Bullet.Settings bulletSettings, Player player)
    {
        _bulletFactory = bulletFactory;
        _bulletSettings = bulletSettings;
        _player = player;
    }

    private void Awake()
    {
        _playerInputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        if (_playerInputHandler.IsShooting && _player.IsAlive && _canShoot)
        {
            Shoot();
            _canShoot = false;
        }

        if (!_playerInputHandler.IsShooting)
        {
            _canShoot = true;
        }
    }

    private void Shoot()
    {
        Bullet bullet = _bulletFactory.Create();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.Init(_bulletSettings.speed);
    }
}

