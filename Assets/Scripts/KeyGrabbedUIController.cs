using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class KeyGrabbedUIController : MonoBehaviour
{
    Image keyImage;

    public Color notGrabbedColor = Color.black;
    public Color grabbedColor = Color.white;

    private void Awake()
    {
        keyImage = GetComponent<Image>();
    }

    public void UpdateIsKeyGrabbed(bool isGrabbed)
    {
        keyImage.color = isGrabbed ? grabbedColor : notGrabbedColor;
    }
}
