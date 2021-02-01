using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField]private GameObject levelSelect;
  

    private void OnMouseDown()
    {
        LevelSelect level=Instantiate(levelSelect).GetComponent<LevelSelect>();
        level.setPlayButton(this);
        gameObject.SetActive(false);
        
    }
}
