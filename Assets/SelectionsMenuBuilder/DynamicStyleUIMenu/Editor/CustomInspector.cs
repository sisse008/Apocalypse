using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(UIMenuStyleController))]
public class CustomInspector : Editor
{

    private GUIStyle buttonStyle;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UIMenuStyleController UIcontroller = (UIMenuStyleController)target;

        if (GUILayout.Button("Add Color"))
        {
            UIcontroller.AddColor();
        }

        if (GUILayout.Button("Remove All Colors"))
        {
            UIcontroller.RemoveAllStyles();
        }

        foreach (Color c in UIcontroller.Colors)
        {
            if (buttonStyle == null)
            {
                buttonStyle = new GUIStyle(GUI.skin.button);
                buttonStyle.normal.textColor = Color.white;
            }

            buttonStyle.normal.textColor = c;

            if (GUILayout.Button("Style!", buttonStyle))
            {
                bool style = UIcontroller.ChangeStyle(c);
                Debug.Log(style?"styling the menu!" : "Cannot style!! color is not in color list!!");
            }
        }

    }
}
