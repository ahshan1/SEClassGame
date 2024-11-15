using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
 

    [SerializeField] TextMeshProUGUI timerText; // need to assign this in inspector. use the text from timer UI.
    [SerializeField] float remainingTime;



    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime; // time between current and previous frame. 
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60); // this gets the amount of seconds passedin a minuite.

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
