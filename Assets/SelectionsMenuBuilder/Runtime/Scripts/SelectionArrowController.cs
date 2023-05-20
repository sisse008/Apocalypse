using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionArrowController : Animations, IAnimatableButton, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    AudioSource clip;

    protected override void Awake()
    {
        clip = GetComponent<AudioSource>();
        base.Awake();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverAnimation();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        PlaySelectedAnimation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetSize();
    }

    public void PlaySelectedAnimation()
    {
        clip.Play();
    }
    public void PlayHoverAnimation()
    {
        Enlarge();
    }
}
