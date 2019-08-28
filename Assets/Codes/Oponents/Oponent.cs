using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
    public float speed;
    virtual  public void Start()
    {
        StartNavAgent();
    }
    public virtual void  StartNavAgent() { }
}
