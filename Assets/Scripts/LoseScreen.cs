using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private Text loseText;
    [SerializeField] private Button restart;
    [SerializeField] private Button back;

    private void Start()
    {
        restart.onClick.AddListener(()=>Global.fader.loadLevel( SceneManager.GetActiveScene().name));
        back.onClick.AddListener(()=>Global.fader.loadLevel("MainMenu"));
    }
    public void setText(int score,bool newRecord=false)
    {
        if (!newRecord)
        {
            loseText.text = "Вы набрали " + score + " очков.";
        }
        else
        {
            loseText.text = "Вы набрали " + score + " очков.Это новый рекорд!";
        }
    }
}
