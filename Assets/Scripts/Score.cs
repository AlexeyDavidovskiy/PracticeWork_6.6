using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private int score;

    [Inject]
    private void Construct(SignalBus signal) 
    {
        signal.Subscribe<ZombieDiedSignal>(OnZombieDied);
    }

    private void OnZombieDied() 
    {
        score++;
        scoreText.text = Convert.ToString(score);
    }
}
  
