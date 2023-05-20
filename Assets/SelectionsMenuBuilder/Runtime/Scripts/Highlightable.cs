using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(DSOutline))]

public class Highlightable : MonoBehaviour, IHighlightable
{
    //TODO: outline should be attached to renderer that highlights
    public DSOutline outline;
    [SerializeField] float outLineWidth = 3;
    bool highlighted;
    protected virtual void Start()
    {
      
        if(outline == null)
            outline = GetComponent<DSOutline>();  
       
        outline.OutlineWidth = outLineWidth;
        highlighted = false;
    }

    protected virtual void Awake()
    {
        
    }

    public void Highlight()
    {
        if (highlighted)
            return;
        outline.ActivateOutline();
        highlighted = true;
    }


    public void UnHighlight()
    {
        if (outline == null)
            Debug.Log("NO OUTLINEEE. NAME = " + name);
        if (highlighted == false)
            return;
        outline.DeactivateOutline();
        highlighted = false;
    }

    public void HighlightDynamic()
    {
        Highlight();
        StartCoroutine(AnimateOutlineWidth());
    }

    IEnumerator AnimateOutlineWidth()
    {
        while (highlighted)
        {
            yield return ChangeOutlineWidth(1, 0);
            yield return ChangeOutlineWidth(1, 30);
        }
    }

    IEnumerator ChangeOutlineWidth(float duration, float targetWidth)
    {
        float timer = 0;
        float currentWidth = outline.OutlineWidth;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            outline.OutlineWidth = Mathf.Lerp(currentWidth, targetWidth, timer / duration);
            yield return null;
        }
    }
}
