using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{ 
    PlayButton playButton;
    [SerializeField] private Button[] levels;
    [SerializeField] private Button back;

    private void Start()
    {
        initializeFields();
    }

    //Устанавливает функции для кнопки назад и выбора уровня
    private void initializeFields()
    {
        back.onClick.AddListener(() =>
        {
            playButton.gameObject.SetActive(true);
            Destroy(gameObject);
        });
        //Временно просто загрузка
        levels[0].onClick.AddListener(()=>SceneManager.LoadScene("Game3x3")); 
        levels[1].onClick.AddListener(()=>SceneManager.LoadScene("Game4x4")); 
    }
    
    //Усстанавливает ссылку на кнопку включающей выбор уровня
    public void setPlayButton(PlayButton play)
    {
        playButton = play;
    }
    
}
