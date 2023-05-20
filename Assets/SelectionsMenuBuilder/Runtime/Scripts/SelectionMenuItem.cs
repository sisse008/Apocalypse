using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionMenuItem<T> : Selectable<T>
{
    public static UnityAction<SelectionMenuItem<T>> OnUIItemSelected;


    protected override void Awake()
    {
        gameObject.AddComponent<Rotate>();

        base.Awake();

    }
    protected override void OnEnable()
    {
        OnUIItemSelected += ObjectSelected;
        base.OnEnable();
    }
    private void OnDisable()
    {
        OnUIItemSelected -= ObjectSelected;
    }

    void ObjectSelected(Selectable<T> item)
    {
        if (item != this) { UnHighlight(); }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!selectable)
            return;
        currentlySelected = this;
        OnUIItemSelected?.Invoke(this);
        base.OnPointerDown(eventData);
    }
}
