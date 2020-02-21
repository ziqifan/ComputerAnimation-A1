using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionAnimation : MonoBehaviour {

    private bool finished = false;
    private string scenename;
    public Vector3 startScale;
    public Vector3 endScale;
    public bool reverse = false;

    void Start()
    {
        if(reverse)
        {
            StartCoroutine(doScale());
        }
    }

    public void doscale(string sceneName)
    {
        scenename = sceneName;
        StartCoroutine(doScale());
    }

    public IEnumerator doScale()
    {
        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, endScale, i);
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
