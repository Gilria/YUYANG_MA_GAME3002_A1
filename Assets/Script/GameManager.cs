using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform enemy;
    public bool isGameOver;
    public GameObject Panel;

    private void Update()
    {
        if(enemy.childCount==0 && isGameOver == false)
        {
            isGameOver = true;
            Panel.SetActive(true);
            
        }
    }


}
