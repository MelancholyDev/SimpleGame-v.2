using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager4x4 : MonoBehaviour
{
    private GameMode4x4 _gameMode4x4;
    private HeartManager heartManager;
    [SerializeField]private Timer timer;
    [SerializeField] private ScoreScreen scoreScreen;
    
    private int correct;
    
    private void Start()
    {
        _gameMode4x4 = new GameMode4x4();
        heartManager = GetComponent<HeartManager>();
        timer = Instantiate(timer);
        scoreScreen = Instantiate(scoreScreen);
        _gameMode4x4.setFields(heartManager,timer,scoreScreen);
        _gameMode4x4.startGame();
    }
}
