using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PageLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    [SerializeField] private Button[] pageButtons;

    private int currentPageIndex = 0;

    private void Start()
    {
        // Set the first page to be visible and others to be invisible
        ShowPage(currentPageIndex);

        // Add click listeners to page buttons
        for (int i = 0; i < pageButtons.Length; i++)
        {
            int pageIndex = i; // To capture the correct value of i in the lambda
            pageButtons[i].onClick.AddListener(() => ShowPage(pageIndex));
        }
    }

    private void ShowPage(int index)
    {
        // Ensure the index is within bounds
        if (index < 0 || index >= pages.Length)
        {
            return;
        }

        // Set the selected page to be visible and others to be invisible
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == index);
        }

        // Update current page index
        currentPageIndex = index;
    }
}