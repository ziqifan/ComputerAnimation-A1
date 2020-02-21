using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAnimation : MonoBehaviour {

    private bool finished = false;
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed = 1.0f;
    public float duration = 3.0f;

    void Start()
    {
        Vector3 buff = startPos;
        startPos.x = Screen.width * buff.x / 1145;
        startPos.y = Screen.height * buff.y / 626;
        buff = endPos;
        endPos.x = Screen.width * buff.x / 1145;
        endPos.y = Screen.height * buff.y / 626;
    }

    public void domove()
    {
        StartCoroutine(doMove());
    }

    public IEnumerator doMove()
    {
        float i = 0.0f;
        float rate = (1.0f / duration) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        yield return finished = true;
    }

    private void LateUpdate()
    {
        if (finished == true)
        {
            Application.Quit();
        }
    }
}
