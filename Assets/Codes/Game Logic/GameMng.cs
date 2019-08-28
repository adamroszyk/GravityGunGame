using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    #region Properties
    public static GameMng instance = null;
    public Player p1;
    public GameObject ball;
    public float timetillTheEnd = 60;
    private int score;
    #endregion
    #region Methods
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            //changing score value is the only place that can result in lvl change
            if (score < value)
            {
                score = value;
                if (LevelMng.instance && GameMng.instance) LevelMng.instance.CheckLevelChange();
            }else score = value;
        }
    }
    void Awake()
    {
        Score = 0;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Update()
    {
        timetillTheEnd -= Time.deltaTime;
    }
    #endregion
}
