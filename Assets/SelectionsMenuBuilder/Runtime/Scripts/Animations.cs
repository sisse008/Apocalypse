using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animations : MonoBehaviour
{
    public Color selectedColor;
    public float duration;
    public float enlargeScaleFactor;

 
    RectTransform rt;
    Vector2 originalSize;

    Vector2 OriginalSize
    {
        get 
        {
            if (originalSize == null || originalSize == Vector2.zero)
            {
                originalSize = rt.sizeDelta;
            }
            return originalSize;
        }
    }

    protected virtual void Awake()
    {   
        rt = GetComponent<RectTransform>();
    }

    private void Start()
    {
        originalSize = rt.sizeDelta;
    }
    protected void Enlarge()
    {
        Vector2 targetSize = OriginalSize * enlargeScaleFactor;
        StartCoroutine(Resize(duration, targetSize)); 
    }

    protected void ResetSize()
    {
        StartCoroutine(Resize(duration, originalSize)); ;
    }

    IEnumerator Resize(float duration, Vector2 targetSize)
    {
        float _time = 0;
        Vector2 currentsize = rt.sizeDelta;
       
        while (_time < duration)
        {
           // Debug.Log("resizing button = " + name + "   rt.sizeDelta = " + rt.sizeDelta + "   targetSize = " + targetSize);
            _time += Time.deltaTime;
            rt.sizeDelta = Vector2.Lerp(currentsize, targetSize, _time / duration);
            yield return null;
        }
    }

    protected void ChangeColor()
    {
        StartCoroutine(ChangeColor(duration));
    }

    IEnumerator ChangeColor(float duration)
    {
        float currentFade = 0;
        Material m = rt.gameObject.GetComponent<MeshRenderer>().material;
        Color currentColor = m.color;
        while (currentFade < duration)
        {
            currentFade += Time.deltaTime;
            m.color = Color.Lerp(currentColor, selectedColor, currentFade / duration);
            yield return null;
        }
    }
}
