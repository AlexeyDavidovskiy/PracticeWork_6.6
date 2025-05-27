using UnityEngine;
using System;
using Zenject;

public class Player : MonoBehaviour
{
    private Settings _settings;
    private bool _isAlive;
    private SignalBus _signal;
    public bool IsAlive => _isAlive;

    [Inject]
    public void Construct(Settings settings, SignalBus signal)
    {
        _settings = settings;
        _signal = signal;
    }

    private void Awake()
    {
        _isAlive = true;
    }

    public void Die() 
    {
        _isAlive = false;
        _signal.Fire(new PlayerDiedSignal());
    }

    [Serializable]
    public class Settings
    { public float Speed; }
}
