using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//2nd round should have 5 potential buttons and 6 button presses
//round 2 mini boss is mad hatter, if player wins he is defeated else player takes damage, lose three times and its game over
public class Round2 : MonoBehaviour
{
    public string gameSceneName;
    public string MainMenu;

    public bool playerwins; //boolean to determine if player won
    public int MHhealth = 1; //Mad Hatter Health
    public int playerHealth = 3;  //player health

    public List<AskAliceObjects> allButtons = new List<AskAliceObjects>();
    private List<Button> GameButtonsPressed = new List<Button>();
    private List<Button> playerButtonsPressed = new List<Button>();

    private int numberOfPresses = 6;
    private int buttonCheck = 0;

    public Button lockAndKey;
    public Button pocketWatch;
    public Button topHat;
    public Button rightTeaCup;
    public Button cheshire;

    // Start is called before the first frame update
    public void Start()
    {
        //calls startRound method
        StartRound();
    }

    public void StartRound()
    {
        //starts PressButtons corutine
        StartCoroutine(PressButtons());
    }

    IEnumerator PressButtons()
    {
        //find canvas in scene
        Canvas canvas = FindObjectOfType<Canvas>();
        //disables buttond for player input
        canvas.GetComponent<GraphicRaycaster>().enabled = false;

        // Disable button component
        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].button.enabled = false;
        }
        for (int i = 0; i < numberOfPresses; i++)
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

        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].button.enabled = true;
        }
        //reeneable buttons
        canvas.GetComponent<GraphicRaycaster>().enabled = true;
    }


    public void PlayerInput()
    {
        for (int i = 0; i < numberOfPresses; i++)
        {
            // if ( button is pressed 
            //Add to list playerButtonsPressed
          //  if ()
        }

        //check that button pressed at each index matches button at the same index in the Game ButtonsPressed list
        for (int I = 0; I < GameButtonsPressed.Count; I++)
        {
            //if playerButtonPressed at index I does not match GameButtonsPressed at index I
            if (playerButtonsPressed[I] != GameButtonsPressed[I])
            {
                //palyerwins is set to false
                playerwins = false;
               
                //calls winCondition
                winCondition();      
            }
            else
           {
                playerwins = true;

                winCondition();
            }   
            }
        }
    
        //winCondition method checks whether the player has won or lost
        // if player wins start new round
        //else player loses 1 health
        public void winCondition()
        {
            //if the player wins
            if (playerwins == true)
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
                if (playerHealth <= 0)
                {
                    //prints Game Over Meassage in the console
                    Debug.Log("Game Over");

                    //calls LoadMain Menu
                    //LoadMainMenu();
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