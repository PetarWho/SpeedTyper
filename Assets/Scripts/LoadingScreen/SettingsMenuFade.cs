using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuFade : MonoBehaviour
{
    public CanvasGroup settingsCanvasGroup;
    public CanvasGroup helpCanvasGroup;
    private bool fadedIn = false;

    public void FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        fadedIn = true;
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1));
    }
    public void FadeOut(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        fadedIn = false;
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0));
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

    private void Update()
    {
        if (fadedIn && Input.GetKeyDown(KeyCode.Escape))
        {
            fadedIn = false;
            FadeOut(settingsCanvasGroup);
            FadeOut(helpCanvasGroup);
        }
    }
}
