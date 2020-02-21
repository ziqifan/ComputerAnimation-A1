using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleMove : MonoBehaviour {

    public Vector3 leftPos, rightPos;
    public float speed = 1.0f;
    public float duration = 3.0f;

    IEnumerator Start()
    {
        Vector3 buff = leftPos;
        leftPos.x = Screen.width * buff.x / 1145;
        leftPos.y = Screen.height * buff.y / 626;
        buff = rightPos;
        rightPos.x = Screen.width * buff.x / 1145;
        rightPos.y = Screen.height * buff.y / 626;

        while (true)
        {
            yield return RepeatLerp(leftPos, rightPos, duration);
            yield return RepeatLerp(rightPos, leftPos, duration);
        }
    }

    IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.5f)
        {
            if (i < 1.0)
            {
                i += Time.deltaTime * rate;
                this.transform.position = Vector3.Lerp(a, b, i);
                yield return null;
            }
            else
            {
                i += Time.deltaTime * rate;
                yield return null;
            }
        }
    }
}
