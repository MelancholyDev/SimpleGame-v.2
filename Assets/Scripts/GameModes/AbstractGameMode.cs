using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGameMode
{
    protected Tile[] board;
    protected GameObject boardPrefab;
    protected GameObject instantinatedBoard;
    protected GameObject loseScreen;
    protected ScoreScreen scoreScreen;
    protected int[] numSet;
    protected int level;
    protected int timerIncrease;
    protected int maxLevel;
    protected int firstCorrect;
    protected int correct;
    protected int health;
    protected int startTimer;
    public int score;
    public GameState state;
    
    protected HeartManager heartManager;
    protected Timer timer;
    
    public void setFields(HeartManager hm,Timer timer,ScoreScreen scoreScreen)
    {
        heartManager = hm;
        timer._abstractGameMode = this;
        this.timer = timer;
        this.scoreScreen = scoreScreen;
    }

    public abstract void startGame();

    protected void upgradeLevel()
    {
        correct = firstCorrect;
        addScore();
        if (level < maxLevel)
            level++;
        timer.increaseTimer(timerIncrease);
        shuffleBoard();
    }

    public void getDamage()
    {
        heartManager.getDamage(health);
        health--;
        if(health==0 & state==GameState.Game)
            lose();
    }

    private void addScore()
    {
        score++;
        scoreScreen.setScore(score);
    }
    public void lose()
    {
        state = GameState.Lose;
        GameObject lose = GameObject.Instantiate(loseScreen);
        lose.GetComponent<LoseScreen>().setText(score);
        GameObject.Destroy(instantinatedBoard);
    }
    protected abstract void shuffleBoard();

    protected void loadLoseScreen()
    {
        loseScreen = Resources.Load<GameObject>("Screens/LoseScreen");
    }
    protected abstract void loadBoard();
    public abstract TileState checkCorrect(Tile tile);
    
}