using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMove : MonoBehaviour {

    public Vector3 leftPos, rightPos;
    public float speed = 1.0f;
    public float duration = 3.0f;
    public float angleOrigin = 0f;
    public float angleTarget = 10f;

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
            yield return RepeatLerp(leftPos, rightPos, Quaternion.Euler(0, 0, angleOrigin + angleTarget), duration);
            yield return RepeatLerp(rightPos, leftPos, Quaternion.Euler(0, 0, angleOrigin - angleTarget), duration);
        }
    }

    IEnumerator RepeatLerp(Vector3 a, Vector3 b, Quaternion c, float time)
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
            else if (i < 1.1)
            {
                i += Time.deltaTime * rate;
                Quaternion target = Quaternion.Euler(0, 0, angleOrigin - angleTarget);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, target, i);
                yield return null;
            }
            else if (i < 1.2)
            {
                i += Time.deltaTime * rate;
                Quaternion target = Quaternion.Euler(0, 0, angleOrigin + angleTarget);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, target, i);
                yield return null;
            }
            else if (i < 1.3)
            {
                i += Time.deltaTime * rate;
                Quaternion target = Quaternion.Euler(0, 0, angleOrigin);
                this.transform.rotation = Quaternion.Slerp(transform.rotation, target, i);
                yield return null;
            }
            else
            {
                i += Time.deltaTime * rate;
                yield return null;
            }

            if (i < 1.0)
            {
                i += Time.deltaTime * rate;
                this.transform.rotation = Quaternion.Slerp(transform.rotation, c, i);
                yield return null;
            }
        }
    }
}
