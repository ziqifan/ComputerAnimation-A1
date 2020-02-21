using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {

    private float Rotatespeed;
    public float MinSpeed = 1f;
    public float MaxSpeed = 3f;
    public float Rotateduration = 3f;

    IEnumerator Start()
    {
        Rotatespeed = MinSpeed;
        while (true)
        {
            StartCoroutine(ChangeSpeed());
            yield return RepeatLerpRotation(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), Rotateduration);
            yield return RepeatLerpRotation(Quaternion.Euler(0, 0, 180), Quaternion.Euler(0, 0, 360), Rotateduration);
        }
    }

    IEnumerator RepeatLerpRotation(Quaternion a, Quaternion b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * Rotatespeed;
        while (i < 1.0f)
        {

            i += Time.deltaTime * rate;
            this.transform.rotation = Quaternion.Slerp(a, b, i);
            yield return null;

        }
    }

    IEnumerator ChangeSpeed()
    {
        while (MaxSpeed > Rotatespeed)
        {
            Rotatespeed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(MaxSpeed - MinSpeed);
        while (Rotatespeed > MinSpeed)
        {
            Rotatespeed -= Time.deltaTime;
            yield return null;
        }
    }
}
