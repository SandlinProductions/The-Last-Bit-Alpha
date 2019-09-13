using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public bool dash;
    public bool timeShift;
    public bool wallStick;

    void Awake()
    {
        dash = false;
        timeShift = false;
        wallStick = false;
    }
}
