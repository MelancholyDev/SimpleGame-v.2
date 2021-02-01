using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    public AbstractGameMode _abstractGameMode;
    private int time;

    public void startTimer(int x)
    {
        StartCoroutine(timer(x));
    }

    IEnumerator timer(int startTimer)
    {
        time = startTimer;
        while (time >= 0)
        {
            timerText.text = time.ToString();
            time--;
            yield return new WaitForSeconds(1);
        }

        if (_abstractGameMode.state == GameState.Game)
            _abstractGameMode.lose();
    }

    public void increaseTimer(int increase)
    {
        Debug.Log(time+" time");
        time += increase;
    }
}