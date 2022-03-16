using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AskAliceManager : MonoBehaviour
{
    //round 1 mini boss is white rabbit, if player wins he is defeated els player takes damage, lose three times and its game over
    public string gameSceneName;
    public string MainMenu;
    public bool playerwins; //boolean to determine if player won
    public int WRhealth = 1;  //white Rabit Health
    public int MHhealth = 1; //Mad Hatter Health
    public int QueenHealth = 2; //shade of the Queen of Hearts health
    public int playerHealth = 3;  //player health
    public List<AskAliceObjects> allButtons = new List<AskAliceObjects>();
    private  List<Button> GameButtonsPressed = new List<Button>();
    private List<Button> playerButtonsPressed = new List<Button>();
    private int numberOfPresses = 4;
    private int buttonCheck = 0;
    int playerpresses = 0;
    // Start is called before the first frame update
 public  void Start()
    {
        //calls startRound method
        StartRound();
    }

   public void StartRound()
    {
        //starts PressButtons corutine
        StartCoroutine(PressButtons());

        StartCoroutine(PlayerPresses());
    }

    IEnumerator PressButtons()
    {
        //find canvas in scene
        Canvas canvas = FindObjectOfType<Canvas>();
        //disables buttond for player input
        canvas.GetComponent<GraphicRaycaster>().enabled = false;
     
        // Disable button component
        for (int i=0; i < allButtons.Count; i++)
        {
            allButtons[i].button.enabled = false;
        }
        for(int i=0; i<numberOfPresses; i++)
        {
            //select random int within range to select random button
            int randomButton = Random.Range(0, allButtons.Count);
            
            allButtons[randomButton].SelectButton();
           
            //adds randomly selected button to list
            GameButtonsPressed.Add(allButtons[randomButton].button);
            //wait 1 second
            yield return new WaitForSeconds(1f);
            //deselect button
            allButtons[randomButton].DeselectButton();

            yield return new WaitForSeconds(1f);
            //print message to debug log
            Debug.Log("Pressed Buttons: " + i + " times");
        }

        for(int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].button.enabled = true;
        }
        //reeneable buttons
        canvas.GetComponent<GraphicRaycaster>().enabled = true;
    }

    IEnumerator PlayerPresses()
    {
        //check the button pressed by player matches button

        //at equivilent index in GamesButtonsPressed list


        for (int i = 0; i < GameButtonsPressed.Count; i++)
        {
            
            
            //if the player has pressed 4 buttons
            if(playerpresses >= numberOfPresses)
            {
                //find canvas in scene
                Canvas canvas = FindObjectOfType<Canvas>();
                //disables buttond for player input
                canvas.GetComponent<GraphicRaycaster>().enabled = false;
            }
        }
            
      
        for (int i =0; i<allButtons.Count; i++)
        {

           
           //  int buttonCheck;

          
            //wait 1 second
            yield return new WaitForSeconds(1f);
        }
    }
    //winCondition method checks whether the player has won or lost
    // if player wins start new round
    //else player loses 1 health
    public void winCondition()
    {
        //if the player wins
        if(playerwins == true)
        {
            //load the next scene
            LoadGameScene();
        }
        //if playerwins is equal to false
        else if (playerwins == false)
        {
            //subtract 1 from player health
            playerHealth -= 1;
            //if player health is less than or equal to 0
            if(playerHealth <= 0)
            {
                //prints Game Over Meassage in the console
                Debug.Log("Game Over");
                
                //calls LoadMain Menu
                LoadMainMenu();
            }
        }
    }
    // LoadGameScene method
    public void LoadGameScene()
    {

        GameSceneManager.Instance.LoadScene(gameSceneName);
    }
    // LoadMainMenu method
    public void LoadMainMenu()
    {

        GameSceneManager.Instance.LoadScene(MainMenu);
    }
}



