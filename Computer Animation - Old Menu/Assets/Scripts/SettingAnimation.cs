using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingAnimation : MonoBehaviour {

    private bool finished = false;
    private string scenename;
    public Vector3 startPos;
    public Vector3 endPos;
    public bool reverse = false;

    void Start ()
    {
        Vector3 buff = startPos;
        startPos.x = Screen.width * buff.x / 1145;
        startPos.y = Screen.height * buff.y / 626;
        buff = endPos;
        endPos.x = Screen.width * buff.x / 1145;
        endPos.y = Screen.height * buff.y / 626;

        if (reverse)
        {
            StartCoroutine(doMove());
        }
    }

    public void domove(string sceneName)
    {
        scenename = sceneName;
        StartCoroutine(doMove());
    }

    public IEnumerator doMove()
    {
        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime;
            this.transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        yield return finished = true;
    }

    private void LateUpdate()
    {
        if ((finished == true) && (reverse == false))
        {
            SceneManager.LoadScene(scenename, LoadSceneMode.Single);
        }
    }

}
