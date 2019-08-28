using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class DisplayHits : MonoBehaviour
{
    string scoreFormatted;
    void Update()
    {
        LevelDependendRendering();
    }
    #region helpers
    public void LevelDependendRendering()
    {
        scoreFormatted = String.Format(LevelMng.instance.settings.display, GameMng.instance.Score); // Score is being added in 100- so we're counting hits by /100
        GetComponent<TextMesh>().text = scoreFormatted;
    }
    #endregion
}
