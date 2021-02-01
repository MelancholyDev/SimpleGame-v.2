using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Manager3x3 : MonoBehaviour
{
    private GameMode3x3 _gameMode3X3;
    private HeartManager heartManager;
    [SerializeField]private Timer timer;
    [SerializeField] private ScoreScreen scoreScreen;
    
    private int correct;
    
    private void Start()
    {
        _gameMode3X3 = new GameMode3x3();
        heartManager = GetComponent<HeartManager>();
        timer = Instantiate(timer);
        scoreScreen = Instantiate(scoreScreen);
        _gameMode3X3.setFields(heartManager,timer,scoreScreen);
        _gameMode3X3.startGame();
    }
    
}
public enum GameState{
    Game,
    NewLevel,
    Lose
}


