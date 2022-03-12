using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{

    public Button mainMenu;
    public Button exitButton;
    public Button resume;
    public Button restart;
    public string gameSceneName;
    //public Button pause;
    public GameObject PauseMenuOnOff;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


    }
    void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuOnOff.SetActive(true);
        isPaused = true;

        mainMenu.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(OnApplicationQuit);
        resume.onClick.AddListener(ResumeGame);
        restart.onClick.AddListener(RestartRound);


    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuOnOff.SetActive(false);
        isPaused = false;
    }
    //add logic to restart  current round
    void RestartRound()
    {

    }
    public void LoadGameScene()
    {

        GameSceneManager.Instance.LoadScene(gameSceneName);
    }
    private void OnApplicationQuit()
    {
        Application.Quit();
    }
}
