using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public CanvasGroup cg;
    public Animator transition;

    private void Start()
    {
        cg.alpha = 1;
    }

    public float transitionTime = 1f;     

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelindex)
    {
        transition.SetTrigger("Start");
         
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelindex);    
    }
} 