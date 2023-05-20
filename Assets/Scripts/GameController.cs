using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] PlayerController playerController;
    [SerializeField] BlackScreenUIController blackScreenUIController;
    [SerializeField] InGameMenuController inGameMenuController;


    private void Awake()
    {
        playerController.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        playerController.OnDead += EndGame;
        playerController.OnOpenedDoor += EndLevel;
    }
    private void OnDisable()
    {
        playerController.OnDead -= EndGame;
        playerController.OnOpenedDoor -= EndLevel;
    }

    public void StartNewGame(Vector3 playerInitPosition, Avatar avatar)
    {
        Instantiate(avatar, playerController.transform);
        playerController.transform.position = playerInitPosition;
        playerController.gameObject.SetActive(true);
    }

    void EndLevel()
    {
        EndGame();
    }

    void EndGame()
    {
        StartCoroutine(IEndGame());
    }

    IEnumerator IEndGame()
    {
        yield return blackScreenUIController.FadeToBlack();
        inGameMenuController.gameObject.SetActive(true);
      //  GameManager.Instance.GoToMenuScene();
    }
}
