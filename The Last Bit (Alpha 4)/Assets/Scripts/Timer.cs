using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finnishedbox = false;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GetComponent<PlayerController>().alive == false)
        {
            Reset();
        }
        if (GetComponent<PlayerController>().finshed == true)
        {
            Finnished();
        }
        if (finnishedbox)
            return;
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
        timerText.color = Color.white;
    }
    void Finnished()
    {
        finnishedbox = true;
        timerText.color = Color.yellow;
    }
    private void Reset()
    {
        startTime = Time.time;
    }

}
