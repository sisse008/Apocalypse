using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectionSceneController : MonoBehaviour
{
    [SerializeField] Button b_backToMenu;

    private void OnEnable()
    {
        b_backToMenu.onClick.AddListener(BackToMenuScene);

        AvatarSelectionMenuItem.OnItemSelected += OnAvatarSelected;
    }

    private void OnDisable()
    {
        b_backToMenu.onClick?.RemoveListener(BackToMenuScene);

        AvatarSelectionMenuItem.OnItemSelected -= OnAvatarSelected;
    }

    public void BackToMenuScene()
    {
        GameManager.Instance.GoToMenuScene();
    }

    public void OnAvatarSelected(Avatar avatar)
    {

        GameManager.Instance.SetSelectedAvatar(avatar);
    }

}
