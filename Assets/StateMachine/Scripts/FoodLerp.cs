using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLerp : MonoBehaviour {

    Vector3 maxScale;
    public Vector3 minScale = new Vector3(0,0,0);
    public float speed = 2f;
    public float duration = 1f;
    public bool lerped = false;

    // Use this for initialization
    IEnumerator Start()
    {
        maxScale = transform.localScale;
        if(!lerped)
        {
            lerped = true;
            yield return Lerp(minScale, maxScale, duration);
        }
    }

    public IEnumerator Lerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
