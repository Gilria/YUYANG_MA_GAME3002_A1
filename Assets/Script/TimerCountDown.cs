using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject PanelDisplay;
    public int secondsLeft = 60;
    public bool takingAway = false;
    public int sencondUsed;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    private void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        if(GetComponent<GameManager>().isGameOver == true)
        {
            StopAllCoroutines();
        }
        sencondUsed = 60 - secondsLeft;

    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;

        PanelDisplay.GetComponent<Text>().text = "You used " + sencondUsed + " Seconds to finish the game!";
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
            //PanelDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
            //PanelDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        
        takingAway = false;
    }




}
