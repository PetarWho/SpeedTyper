using UnityEngine;
using UnityEngine.EventSystems;

public class HoverToDisplayMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject TextToDisplay;

    private void Awake()
    {
        TextToDisplay.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        TextToDisplay.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TextToDisplay.SetActive(false);

    }
}