using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSceneController : MonoBehaviour
{
    [SerializeField] Button b_play;
    [SerializeField] Button b_playerSelection;

    private void OnEnable()
    {
        b_play.onClick.AddListener(StartNewGame);
        b_playerSelection.onClick.AddListener(SelectPlayer);
    }

    private void OnDisable()
    {
        b_play.onClick?.RemoveListener(StartNewGame);
        b_playerSelection.onClick?.RemoveListener(SelectPlayer);
    }

    public void StartNewGame()
    {
        GameManager.Instance.StartGame();
    }


    void SelectPlayer()
    {
        GameManager.Instance.GoToSelectionScene();
    }
}
