using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMove : MonoBehaviour {

    public Vector3 startPos, endPos;
    public float Movespeed = 30.0f;
    public float Moveduration = 3.0f;
    public Vector3 minScale;
    public Vector3 maxScale;
    public float Scalespeed = 2f;
    public float Scaleduration = 5f;
    public float angleOrigin;
    public float angleTarget;
    public float Rotatespeed = 1f;
    public float Rotateduration = 3f;

    IEnumerator Start()
    {
        Vector3 buff = startPos;
        startPos.x = Screen.width * buff.x / 1145;
        startPos.y = Screen.height * buff.y / 626;
        buff = endPos;
        endPos.x = Screen.width * buff.x / 1145;
        endPos.y = Screen.height * buff.y / 626;

        while (true)
        {
            yield return RepeatLerpMovement(startPos, startPos + (endPos - startPos) / 3 * 2, Moveduration * 10);
            yield return RepeatLerpMovement(startPos + (endPos - startPos) / 3 * 2, endPos, Moveduration);
            yield return RepeatLerpScale(minScale, maxScale, Scaleduration);
            yield return RepeatLerpRotation(Quaternion.Euler(0, 0, angleOrigin + angleTarget), Rotateduration);
            yield return RepeatLerpRotation(Quaternion.Euler(0, 0, angleOrigin - 2 * angleTarget), Rotateduration);
            yield return RepeatLerpRotation(Quaternion.Euler(0, 0, angleOrigin), Rotateduration);
            yield return RepeatLerpScale(maxScale, minScale, Scaleduration);
            yield return RepeatLerpMovement(endPos, startPos, Moveduration*5);
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

    IEnumerator RepeatLerpMovement(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * Movespeed;
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
