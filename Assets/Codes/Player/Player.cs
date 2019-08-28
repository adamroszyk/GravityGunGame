using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Properties
    public Transform anchorPoint;
    public GameObject gunPrefab;
    private GameObject mainGun;
    #endregion  

    private void Start()
    {
        InitialiseGun();
    }

    #region Helper's methods
    private void InitialiseGun()
    { 
        mainGun = Instantiate(gunPrefab, new Vector3(-4.460999f, 2, -0.5000001f), Quaternion.identity); //Position=Gun transform from editor
        mainGun.transform.SetParent(anchorPoint);
    }
    #endregion
}
