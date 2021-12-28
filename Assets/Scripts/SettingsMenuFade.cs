using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuFade : MonoBehaviour
{
    public CanvasGroup canvasGroupObject;

    public void FadeIn()
    {
        canvasGroupObject.interactable = true;
        canvasGroupObject.blocksRaycasts = true;
        StartCoroutine(FadeCanvasGroup(canvasGroupObject, canvasGroupObject.alpha, 1));
    }
    public void FadeOut()
    {
        canvasGroupObject.interactable = false;
        canvasGroupObject.blocksRaycasts = false;
        StartCoroutine(FadeCanvasGroup(canvasGroupObject, canvasGroupObject.alpha, 0));
    }
    public IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float lerpTime = 0.3f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        while (true)
        {       
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(start, end, percentageComplete);
            canvasGroup.alpha = currentValue;
            if (percentageComplete >= 1)
                break;
            yield return new WaitForEndOfFrame();
        }
    }
}
