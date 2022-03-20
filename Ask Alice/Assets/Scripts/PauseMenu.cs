using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{

    public Button mainMenu;
    public Button exitButton;
    public Button resume;
    public Button restartLevel;
    public Button restartGame;
    public string thisGameSceneName;
    public string firstGameSceneName;
    public string gameSceneName;
    //public Button pause;
    public GameObject PauseMenuOnOff;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Awake()
    {
        PauseMenuOnOff.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //calls the resumeGame method
                ResumeGame();
            }
            else
            {
                //calls the Pause Game Method
                PauseGame();
            }
        }


    }
    void PauseGame()
    {
        Time.timeScale = 0; //pause time in the game
        PauseMenuOnOff.SetActive(true);
        isPaused = true;

        mainMenu.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(OnApplicationQuit);
        resume.onClick.AddListener(ResumeGame);
        restartGame.onClick.AddListener(ReStartGame);


    }
    //resumeGame method
    void ResumeGame()
    {
        Time.timeScale = 1; //unpause the game
        PauseMenuOnOff.SetActive(false); //
        isPaused = false; //set boolean to false
    }
    
  
    public void LoadGameScene()
    {
        //loads the main menu
        GameSceneManager.Instance.LoadScene(gameSceneName);
    }

    public void ReStartGame()
    {
        //re loads the scene
        GameSceneManager.Instance.LoadScene(firstGameSceneName);
        Time.timeScale = 1;
    }
    public void ReStartLevel()
    {
        GameSceneManager.Instance.LoadScene(thisGameSceneName);
        Time.timeScale = 1;
    }
    private void OnApplicationQuit()
    {
        //quit application
        Application.Quit();
    }
}
