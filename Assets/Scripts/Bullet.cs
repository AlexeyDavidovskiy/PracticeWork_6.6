using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private float _lifeTime = 5f;

    [Inject]
    private SignalBus signal;

    public void Init(float speed)
    {
        _speed = speed;
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Zombie zombie)) 
        {
            Destroy(zombie.gameObject);
            signal.Fire(new ZombieDiedSignal());
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class Settings 
    {
        public float speed;
    }

    public class BulletFactory : PlaceholderFactory<Bullet> { }
}
