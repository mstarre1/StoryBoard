using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storybook : MonoBehaviour
{

    public CanvasGroup PreviousButtonCG;
    public CanvasGroup NextButtonCG;
    public List<CanvasGroup> PageCGs;

    private int totalPages;
    private int currentPage;


    // Start is called before the first frame update
    void Start()
    {
        totalPages = PageCGs.Count;
        currentPage = 1;
        UpdatePages();
        UpdateButtons();
    }

    public void OnPreviousButtonClick()
    {
        currentPage--;
        if (currentPage < 1) currentPage = 1;
        UpdatePages();
        UpdateButtons();
    }

    public void OnNextButtonClick()
    {
        currentPage++;
        if (currentPage > totalPages) currentPage = totalPages;
        UpdatePages();
        UpdateButtons();
    }

    public void UpdatePages()
    {
        foreach (CanvasGroup cg in PageCGs)
        {
            Hide(cg);
        }
        Show(PageCGs[currentPage - 1]);
    }

    public void UpdateButtons()
    {
        Show(PreviousButtonCG);
        Show(NextButtonCG);
        if (currentPage == 1) Hide(PreviousButtonCG);
        if (currentPage == totalPages) Hide(NextButtonCG);
    }

    private void Show(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
