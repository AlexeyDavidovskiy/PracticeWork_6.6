using UnityEngine;
using System;
using Zenject;

public class Player : MonoBehaviour
{
    private Settings _settings;
    private bool _isAlive;
    public bool IsAlive => _isAlive;

    [Inject]
    public void Construct(Settings settings)
    {
        _settings = settings;
    }

    private void Awake()
    {
        _isAlive = true;
    }
    private void Start()
    {
        
    }

    [Serializable]
    public class Settings
    { public float Speed; }
}
