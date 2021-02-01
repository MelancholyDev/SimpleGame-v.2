using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private int num;
    [SerializeField] private TextMeshPro numberOnTile;
    public AbstractGameMode gameMode;

    private void Awake()
    {
        numberOnTile = GetComponentInChildren<TextMeshPro>();
    }

    public int getNum()
    {
        return num;
    }

    public void changeNum(int num)
    {
        if (num == -1)
        {
            numberOnTile.text = "";
        }
        else
        {
            this.num = num;
            numberOnTile.text = num.ToString();
        }
    }

    private void OnMouseDown()
    {
        TileState ts = gameMode.checkCorrect(this);
        if(ts==TileState.Correct)
            changeNum(-1);
        
    }
}
public enum TileState{
Incorrect,
Correct,
CorrectLast
}