using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    [SerializeField]private GameObject prefabHearts;
    private Animator[] hearts;

    public void showHearts()
    {
        hearts=Instantiate(prefabHearts).GetComponentsInChildren<Animator>();
    }

    public void getDamage(int health)
    {
        int heart = 3 - health;
        Debug.Log("damage!");
        hearts[heart].SetTrigger("Damage");
    }
}
