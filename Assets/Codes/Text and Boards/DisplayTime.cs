using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    void Update()
    {
        TimeSpan t = TimeSpan.FromSeconds(GameMng.instance.timetillTheEnd);
        string timerFormatted = String.Format(@"{0:mm\:ss\.ff}", t);
        GetComponent<TextMesh>().text = timerFormatted;

    }
}
