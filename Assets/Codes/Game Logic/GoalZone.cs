using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    #region Properties
    public int value;
    private Vector3 originalSize;
    public Material regular;
    public Material touched;
    #endregion

    public void Awake()
    {
        originalSize = transform.localScale;        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            GainedScore();
        }
    }
    #region Helper's methods
    public void GainedScore()
    {
        GameMng.instance.Score += value;
        RenderAsTouched();
    }

    private void RenderAsTouched()
    {
        transform.localScale = new Vector3(4, 4, 4);
        StartCoroutine(RenderNormally());
        GetComponent<Renderer>().material = touched;
    }

    IEnumerator RenderNormally()
    {
        while (transform.localScale.x > originalSize.x)
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.9f, transform.localScale.z * 0.9f);
            yield return new WaitForSeconds(0.001f);
        }
        GetComponent<Renderer>().material = regular;
    }
    #endregion
}
