using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class GameMode3x3 : AbstractGameMode
{
    public GameMode3x3()
    {
        firstCorrect = 1;
        loadBoard();
        maxLevel = 9;
        correct = 1;
        numSet = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
        level = 1;
        health = 3;
        score = 0;
        startTimer = 10;
        timerIncrease = 5;
        state = GameState.Game;
    }

    public override void startGame()
    { 
        loadLoseScreen();
        InstantinateBoard();
        shuffleBoard();
        timer.startTimer(startTimer);
        heartManager.showHearts();
    }

    protected override void shuffleBoard()
    {
        System.Random rnd = new System.Random();
        for (int i = 0; i < 100; i++)
        {
            int j = rnd.Next(0, 9);
            int k = rnd.Next(0, 9);
            Tile tmp = board[j];
            board[j] = board[k];
            board[k] = tmp;
        }

        for (int i = 0; i < level; i++)
        {
            board[i].changeNum(numSet[i]);
        }

        for (int i = level; i < board.Length; i++)
        {
            board[i].changeNum(-1);
        }
    }

    public int nextCorrect(int previous)
    {
        if (previous == level)
            return -1;
        else
        {
            return previous + 1;
        }
    }

    public void InstantinateBoard()
    {
        instantinatedBoard = GameObject.Instantiate(boardPrefab);
        board = instantinatedBoard.GetComponentsInChildren<Tile>();
        for (int i = 0; i < board.Length; i++)
        {
            board[i].gameMode = this;
        }
    }

    protected override void loadBoard()
    {
        boardPrefab = Resources.Load<GameObject>("Boards/3x3Board");
    }

    public override TileState checkCorrect(Tile tile)
    {
        if (tile.getNum() == correct)
        {
            correct = nextCorrect(correct);
            if (correct == -1)
            {
                upgradeLevel();
                return TileState.CorrectLast;
            }

            return TileState.Correct;
        }
        else
        {
            getDamage();
            return TileState.Incorrect;
        }
    }
}