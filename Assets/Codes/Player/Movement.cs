using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    #region properties
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float aimSensitivity = 8.0f;
    public int aimMin=-50;
    public int aimMax=10;
    Player p1;
    #endregion
    #region Start & Update
    private void Start()
    {
        p1 = GameMng.instance.p1;
    }
    void Update()
    {
        Walking();
        Aiming();
    }
    #endregion
    #region Helper methods
    private void Walking()
    {
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }
    private void Aiming()
    {
        float rotX = -Input.mousePosition.y / aimSensitivity;
        rotX=ApplyLimits(rotX);
        Quaternion rotation = Quaternion.Euler(rotX, p1.anchorPoint.rotation.eulerAngles.y, p1.anchorPoint.rotation.eulerAngles.z);
        p1.anchorPoint.rotation = rotation;
    }
    public float ApplyLimits(float val) {
        if (val < -55) val = -50;
        if (val > 15) val = 10;
        return val;
    }
    #endregion
}
