using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image faderImage;
    private float speed=1;

    private void Start()
    {
        faderImage.color = new Color(0,0,0, 1);
        StartCoroutine(startGameFade());
    }

    public void loadLevel(string levelName)
    {
        StartCoroutine(loadLevelWithFade(levelName));
    }

    IEnumerator startGameFade()
    {
        while (faderImage.color.a >= 0.001)
        {
            faderImage.color = new Color(0,0,0,faderImage.color.a-speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        faderImage.raycastTarget = false;
    }

    IEnumerator loadLevelWithFade(string levelName)
    {
        faderImage.raycastTarget = true;
        while (faderImage.color.a <= 0.999)
        {
            faderImage.color = new Color(0,0,0,faderImage.color.a+speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene(levelName);
        
        while (faderImage.color.a >= 0.001)
        {
            faderImage.color = new Color(0,0,0,faderImage.color.a-speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        faderImage.raycastTarget = false;
    }
    
}
