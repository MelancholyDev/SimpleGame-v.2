using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField]private Text score;

    public void setScore(int score)
    {
        this.score.text=score.ToString();
    }
}
