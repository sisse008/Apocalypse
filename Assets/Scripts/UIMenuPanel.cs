using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class UIMenuPanel : MonoBehaviour
{

    CanvasGroup canvasGroup;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void TogglePanel(bool open)
    {
        if (open)
            OpenPanel();
        else
            ClosePanel();
    }
    public void OpenPanel()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void ClosePanel()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

    }
}
