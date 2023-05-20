using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuStyleController : MonoBehaviour
{
    public List<Image> imagesToModify;
    public List<TMP_Text> textToModify;

    [SerializeField] Color styleColor;

    public class Style
    {
        public Color color;
        static List<Image> imagesToModify;
        static List<TMP_Text> textToModify;

        public Style(Color color, List<Image> imagesToModify, List<TMP_Text> textToModify)
        { 
            this.color = color;
            Style.imagesToModify = imagesToModify;
            Style.textToModify = textToModify;
    }

        public void UseStyle()
        {
            foreach (Image image in Style.imagesToModify)
            {
                image.color = color;
            }
            foreach (TMP_Text text in textToModify)
            {
                text.color = color;
            }
        }
    }



    public List<Color> Colors => new List<Color>(styleDictionary.Keys);


    Dictionary<Color, Style> styleDictionary = new Dictionary<Color, Style>();

   

    public void AddColor()
    {
        AddStyle(styleColor);
    }

    void AddStyle(Color color)
    {
        styleDictionary[color] = new Style(color, imagesToModify, textToModify);
    }

    public void RemoveStyle(Color color)
    {
        if (styleDictionary.ContainsKey(color))
        {
            styleDictionary.Remove(color);
        }
    }

    public void RemoveAllStyles()
    {
        if(styleDictionary.Count != 0)
            styleDictionary.Clear();
    }

    public bool ChangeStyle(Color color)
    {
        if (styleDictionary.ContainsKey(color))
        {
            styleDictionary[color].UseStyle();
            return true;
        }
        return false;
    }
}

public class TMP_Text<T>
{
}