using System.Collections;
using UnityEngine;
using Zenject;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    private Zombie.Factory _zombieFactory;
    private Settings _settings;
    private Player _player;

    [Inject]
    public void Construct(Settings settings, Zombie.Factory zombieFactory, Player player) 
    {
        _zombieFactory = zombieFactory;
        _settings = settings;
        _player = player;
    }

    private void Start()
    {
        StartCoroutine(Process());
    }

    private IEnumerator Process() 
    {
       while (_player.IsAlive) 
        {
            yield return new WaitForSeconds(_settings.Interval);
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Vector3 position = spawnPoint.position;
            Zombie zombie = _zombieFactory.Create();
            zombie.transform.position = position;
        }
    }

    [System.Serializable]
    public class Settings 
    {
        public float Interval;
    }
}
