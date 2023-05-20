using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuGenerator : MonoBehaviour
{

    [SerializeField] LevelMenuButton levelButtonPrefab;

    static Dictionary<LevelMenuButton, LevelConfiguration> buttonToLevel = new Dictionary<LevelMenuButton, LevelConfiguration>();

    public void GenerateButtons(List<LevelConfiguration> gameLevels)
    {
        buttonToLevel.Clear();

        foreach (LevelConfiguration level in gameLevels)
        {
            LevelMenuButton levelButton = Instantiate(levelButtonPrefab, transform);

            levelButton.Init(level.level_name, OnLevelSelected);
           
            buttonToLevel.Add(levelButton, level);
        }
    }

    public void HighlightPreviouslySelectedLevel(LevelConfiguration prevSelected)
    {
        foreach (KeyValuePair<LevelMenuButton, LevelConfiguration> pair in buttonToLevel)
        {
            if (pair.Value == prevSelected)
            {
                LevelMenuButton button = pair.Key;
                button.Highlight();
            }
        }
    }

    void OnLevelSelected(LevelMenuButton button)
    {
        if (buttonToLevel.ContainsKey(button) == false)
        {
            Debug.LogError("cannot load selected scene, it was not added to the dictionary");
            return;
        }
        GameManager.Instance.SetSelectedLevel(buttonToLevel[button]);
    }
}
