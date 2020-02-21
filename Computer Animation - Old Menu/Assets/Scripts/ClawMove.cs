using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMove : MonoBehaviour {

    public Vector3 minScale;
    public Vector3 maxScale;
    private float Scalespeed = 1f;
    private float Scaleduration = 1f;
    public float angleOrigin = 0f;
    public float angleTarget = 20f;
    private float Rotatespeed = 1f;
    private float Rotateduration = 1f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return RepeatLerpScale(minScale, maxScale, Scaleduration);
            yield return RepeatLerpRotation(Quaternion.Euler(0, 0, angleOrigin), Rotateduration);
            yield return RepeatLerpScale(maxScale, minScale, Scaleduration * 0.5f);
            yield return RepeatLerpRotation(Quaternion.Euler(0, 0, angleOrigin + angleTarget), Rotateduration);
        }
    }

    IEnumerator RepeatLerpScale(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * Scalespeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }

    IEnumerator RepeatLerpRotation(Quaternion a, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * Rotatespeed;
        while (i < 1.0f)
        {

            i += Time.deltaTime * rate;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, a, i);
            yield return null;

        }
    }
}
