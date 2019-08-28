using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterStart : MonoBehaviour
{
    public float time=1;
    void Start()
    {
        StartCoroutine(DisableCanvaRendering(time));
    }

    public IEnumerator DisableCanvaRendering(float timeToLoad)
    {
        yield return new WaitForSeconds(timeToLoad);
        GetComponent<Canvas>().enabled = false;
    }
}
