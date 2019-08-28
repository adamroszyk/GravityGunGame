using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LvlSettings : ScriptableObject
{
    [Header("Level")]
    public int scoreToWin;
    public int NextScene;
    public float waitTime;
    public string display;    
}