using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressMe : MonoBehaviour
{
    //both buttons lead to the first scene in the game
    public Button leftPressMe;
    public Button rightPressMe;
    public string gameSceneName;
    // Start is called before the first frame update
    void Start()
    {

      leftPressMe.onClick.AddListener(LoadGameScene);
      rightPressMe.onClick.AddListener(LoadGameScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Update is called once per frame
    public void LoadGameScene()
    {

        GameSceneManager.Instance.LoadScene(gameSceneName);
    }
}
