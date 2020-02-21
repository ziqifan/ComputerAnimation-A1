using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour {

    public float duration = 1.0f;

    IEnumerator Start()
    {
        while(true)
        {
            yield return FadeCanvasGroup(GetComponent<CanvasGroup>(), GetComponent<CanvasGroup>().alpha, 1, duration);
        }
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1.0f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        _timeStartedLerping = Time.time;
        timeSinceStarted = Time.time - _timeStartedLerping;
        percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(end, start, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
