using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuFade : MonoBehaviour
{
    public CanvasGroup settingsCanvasGroup;
    public CanvasGroup helpCanvasGroup;
    public CanvasGroup changeNameCanvasGroup;
    private bool fadedIn = false;

    public void FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        PressESCtoGoToDifferentScene.escHasOverlay = true;
        fadedIn = true;
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1));

    }
    public void FadeOut(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        PressESCtoGoToDifferentScene.escHasOverlay = false;
        fadedIn = false;
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0));
    }

    public void blockRaycastsOnClick(GameObject menuToBlockRaycast)
    {
        menuToBlockRaycast.GetComponents<Image>()[0].raycastTarget=true;
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
