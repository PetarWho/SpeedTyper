using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadCampaignLevel : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private string level;

    public void LoadLevel()
    {
        level = EventSystem.current.currentSelectedGameObject.name;
        slider.gameObject.SetActive(true);
        LevelLoader.staticDifficulty = level;
        StartCoroutine(LoadAsynchronously("Main"));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}