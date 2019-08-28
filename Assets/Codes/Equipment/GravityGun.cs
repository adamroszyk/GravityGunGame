using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : Gun
{
    #region Properties
    public GameObject attractor; // point to which ball is approaching
    public ParticleSystem ps;
    float speed = 5;
    float range=8;
    float particlesEmmisionRate = 30;
    #endregion

    #region Mouse Btn's Actions
    public override void MouseBtnDown()
    {
        var module = ps.emission;
        module.rateOverTime = particlesEmmisionRate;
        if (BallIsinRangeToCatch() && !GunLoaded())
        {
            PullBall();
        }
        if (GunLoaded()) HoldBall();
    }

    public override void MouseBtnUp()
    {
        var module = ps.emission;
        module.rateOverTime = 0;
        if (GunLoaded())
        {
            Vector3 dir = attractor.transform.position - p1.anchorPoint.transform.position;
            ball.GetComponent<Rigidbody>().AddForce(dir * 1000000);
        }
    }
    #endregion

    #region Helpers methods
    private bool GunLoaded()
    {
        if (BallIsinRangeToHold())
        {
            return true;
        }
        else return false;
    }


    public bool BallIsinRangeToCatch() {
        if (Vector3.Distance(ball.transform.position, p1.transform.position) < range) return true;
        else return false;
    }
    private bool BallIsinRangeToHold()
    {
        if (Vector3.Distance(ball.transform.position, attractor.transform.position) < 1) return true;
        else return false;
       
    }
    private void HoldBall()
    {
        ball.transform.position = attractor.transform.position;
        var module = ps.emission;
        module.rateOverTime = 0;
        ball.GetComponent<Rigidbody>().Sleep();
    }
    private void PullBall()
    {
        ball.GetComponent<Rigidbody>().velocity = (attractor.transform.position - ball.transform.position) * speed;
    }
    #endregion
}
