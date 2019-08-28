using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisplayScore : MonoBehaviour
{
    void Update()
    {
        string scoreFormatted = String.Format(@"{0:D4}", GameMng.instance.Score);
        GetComponent<TextMesh>().text=scoreFormatted;
    }
}
