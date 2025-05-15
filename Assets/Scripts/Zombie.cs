using System;
using UnityEngine;
using Zenject;

public class Zombie : MonoBehaviour
{
    private Settings _settings;
   

    //public Vector3 Position;

    [Inject]
    public void Construct(Settings settings) 
    {
        _settings = settings;
    }

    [Serializable]
    public class Settings 
    {
        public float Speed;
    }

    public class Factory : PlaceholderFactory<Zombie> 
    {
    }
}
