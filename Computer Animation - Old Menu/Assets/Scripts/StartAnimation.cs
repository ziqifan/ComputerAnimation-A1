using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnimation : MonoBehaviour {

    private bool finished = false;
    private string scenename;
    public float lerpTime = 1.0f;
    public float start = 1;
    public float end = 0;
    public bool reverse = false;

    void Start()
    {
        if (reverse)
        {
            StartCoroutine(DoFade());
        }
    }

    public void dofade(string sceneName)
    {
        scenename = sceneName;
        StartCoroutine(DoFade());
    }

    public IEnumerator DoFade()
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (reverse)
        {
            while (canvasGroup.alpha < 1)
            {
                timeSinceStarted = Time.time - _timeStartedLerping;
                percentageComplete = timeSinceStarted / lerpTime;
                float currentValue = Mathf.Lerp(start, end, percentageComplete);
                canvasGroup.alpha = currentValue;
                yield return null;
            }
        }
        else
        {
            while (canvasGroup.alpha > 0)
            {
                timeSinceStarted = Time.time - _timeStartedLerping;
                percentageComplete = timeSinceStarted / lerpTime;
                float currentValue = Mathf.Lerp(start, end, percentageComplete);
                canvasGroup.alpha = currentValue;
                yield return null;
            }
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
