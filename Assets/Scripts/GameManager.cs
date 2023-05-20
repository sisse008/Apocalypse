using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] LevelConfiguration defaultLevel;
    [SerializeField] List<LevelConfiguration> allGameLevels;

    [SerializeField] Avatar defaultAvatar;

    List<LevelConfiguration> AllGameLevels
    {
        get 
        {
            if (allGameLevels.Count == 0)
            {
                Debug.LogError("allGameLevels List is empty. using default Game level");
                allGameLevels = new List<LevelConfiguration>() { defaultLevel };
            }
            return allGameLevels;
        }
    }


    //assign this in menu scene
    LevelConfiguration selectedGameLevel;
    LevelConfiguration SelectedGameLevel
    {
        get 
        {
            if (selectedGameLevel == null)
            {
                Debug.LogError("selectedGameLevel was not set. using first gameLevel in allGameLevels List");
                selectedGameLevel = AllGameLevels[0];
            }
            return selectedGameLevel;
        }
    }

    //assign this in menu scene
    Avatar selectedAvatar;
    Avatar SelectedAvatar
    {
        get 
        {
            if (selectedAvatar == null)
            {
                Debug.LogError("player was not selected. using default avatar");
                selectedAvatar = defaultAvatar;
            }
            return selectedAvatar;

        }
    }

    ReffrenceHolder reffrenceHolder;
    public ReffrenceHolder ReffrenceHolder
    {
        get
        {
            if (reffrenceHolder == null)
                reffrenceHolder = GetComponent<ReffrenceHolder>();
            return reffrenceHolder;
        }
    }

    const int gameSceneIndex = 1;
    const int menuSceneIndex = 0;
    const int selectionSceneIndex = 2;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == gameSceneIndex)
        {
            InitGameScene();
        }
        else if (scene.buildIndex == menuSceneIndex)
        {
            InitMenuScene();
        }
        else if (scene.buildIndex == selectionSceneIndex)
        {
            InitSelectionScene();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void SetSelectedAvatar(Avatar selectedAvatar)
    {
        this.selectedAvatar = selectedAvatar;
    }
    public void SetSelectedLevel(LevelConfiguration selectedLevel)
    {
        selectedGameLevel = selectedLevel;
    }

    public void GoToSelectionScene()
    {
        SceneManager.LoadScene(selectionSceneIndex);
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(menuSceneIndex);
    }

    void InitMenuScene()
    {
        LevelMenuGenerator levelMenuGenerator = FindObjectOfType<LevelMenuGenerator>(true);
        if (levelMenuGenerator == null)
        {
            Debug.LogError("No levelMenuGenerator found in menu Scene! cannot initiate menu");
            return;
        }

        levelMenuGenerator.GenerateButtons(AllGameLevels);
        if(selectedGameLevel)
            levelMenuGenerator.HighlightPreviouslySelectedLevel(selectedGameLevel);
    }

    void InitGameScene()
    {
        PlatformGenerator platformManager = FindObjectOfType<PlatformGenerator>();
        if (platformManager == null)
        {
            Debug.LogError("No Platform Manager found in Game Scene! cannot initiate platforms");
            return;
        }

        Vector3 platformsInitPosition = platformManager.GenerateLevelPlatforms(SelectedGameLevel);

        GameController gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("No game controller found in Game Scene! cannot initiate game");
            return;
        }

        gameController.StartNewGame(platformsInitPosition, SelectedAvatar);
    }

    void InitSelectionScene()
    {
        //TODO:highlight avatar that was previously selected
    }
    
}
