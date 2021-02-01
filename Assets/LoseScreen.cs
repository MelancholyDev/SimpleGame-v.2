using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]private Text loseText;

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
