using UnityEngine;

public class ToggleObjectsOffOn : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void DisableGameObject(GameObject go)
    {
        go.SetActive(false);
    }
    
    public void EnableGameObject(GameObject go)
    {
        go.SetActive(true);
    }
}
