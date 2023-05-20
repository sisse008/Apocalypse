using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelMenuButton : MonoBehaviour
{
    Button button;

    [SerializeField] TMP_Text text;
    [SerializeField] Image bg;
    [SerializeField] Color c_highlight;
    [SerializeField] Color c_noneHighlight;

    public static UnityAction<LevelMenuButton> OnSelected;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Init(string _name, UnityAction<LevelMenuButton> onClickAction)
    {
        text.text = _name;
        button.onClick.AddListener(() => onClickAction?.Invoke(this));
    }

    private void OnEnable()
    {
        button.onClick.AddListener(() => OnSelected?.Invoke(this));
        OnSelected += ToggleHighlight;
    }

    void ToggleHighlight(LevelMenuButton b)
    {
        if (b == this)
            Highlight();
        else
            Unhighlight();
    }

    public void Highlight() => bg.color = c_highlight;
    public void Unhighlight() => bg.color = c_noneHighlight;


    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
        OnSelected -= ToggleHighlight;
    }
}
