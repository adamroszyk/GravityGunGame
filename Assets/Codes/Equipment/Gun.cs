using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Properties
    public GameObject ball;
    public Player p1;
    #endregion

    public void Start()
    {
        p1 = GameMng.instance.p1;
        ball = GameMng.instance.ball;
    }

    void Update()
    {
        CheckInput();
    }

    #region Helper Methods
    public void CheckInput()
    {
        if (Input.GetMouseButton(0)) MouseBtnDown();
        if (Input.GetMouseButtonUp(0)) MouseBtnUp();
    }
    public virtual void MouseBtnDown() { }
    public virtual void MouseBtnUp() { }
    #endregion
}
