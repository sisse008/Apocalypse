using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuController : MonoBehaviour
{

    [SerializeField] Button exit;
    [SerializeField] Button play;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        exit.onClick.AddListener( () => GameManager.Instance.GoToMenuScene());
        play.onClick.AddListener( () => GameManager.Instance.StartGame());
    }

    private void OnDisable()
    {
        exit.onClick?.RemoveListener( () => GameManager.Instance.GoToMenuScene());
        play.onClick?.RemoveListener( () => GameManager.Instance.StartGame());
    }


}
