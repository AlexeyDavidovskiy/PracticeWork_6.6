using System;
using UnityEngine;
using Zenject;

public class Zombie : MonoBehaviour
{
    private Settings _settings;
    private SignalBus _signal;

    [Inject]
    public void Construct(Settings settings, SignalBus signal) 
    {
        _settings = settings;
        _signal = signal;
    }

    [Serializable]
    public class Settings 
    {
        public float Speed;
    }

    public class Factory : PlaceholderFactory<Zombie> 
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Destroy(player.gameObject);
            _signal.Fire(new PlayerDiedSignal());
        }
    }
}
