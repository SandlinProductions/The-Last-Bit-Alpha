﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
  
    public Abilities abilities;

    private void Awake()
    {
        abilities = FindObjectOfType<Abilities>();
    }
    //This is how we slow it all down.
    void Update()
    {
        if (abilities.GetComponent<Abilities>().timeShift == true)
        {
            if (Input.GetButtonDown("Time") & PauseMenu.GameIsPaused == false)
            {
                if (Time.timeScale == 1.0F)
                    Time.timeScale = 0.2F;
                else
                    Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
        }
    }
}
