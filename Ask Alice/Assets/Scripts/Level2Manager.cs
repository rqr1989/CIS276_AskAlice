using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//2nd round should have 5 potential buttons and 6 button presses
//round 2 mini boss is mad hatter, if player wins he is defeated else player takes damage, lose three times and its game over
public class Level2Manager : MonoBehaviour
{
    public string gameSceneName;
    public string MainMenu;

    public bool playerwins; //boolean to determine if player won
    public int MHhealth = 1; //Mad Hatter Health
    public int playerHealth = 3;  //player health
    public int enemyHealth = 3;
    public List<AskAliceObjects> allButtons = new List<AskAliceObjects>();
    private List<Button> GameButtonsPressed = new List<Button>();
    private List<Button> playerButtonsPressed = new List<Button>();

    private int numberOfPresses = 6;
   
    int playerpresses = 0;
    int currentRound = 1;
    public Button lockAndKey;
    public Button pocketWatch;
    public Button topHat;
    public Button rightTeaCup;
    public Button cheshire;
    public float time = 1f;
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

        //starts playerPresses corutine
        StartCoroutine(PlayerPresses());
        //calls CheckInput method
        CheckInput();
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


    IEnumerator PlayerPresses()
    {
        for (int i = 0; i < GameButtonsPressed.Count; i++)
        {
            //Need Logic Here To Add Buttons Pressed to playerButtonsPressed

            //if the player has pressed 4 buttons
            if (playerpresses >= numberOfPresses)
            {
                //find canvas in scene
                Canvas canvas = FindObjectOfType<Canvas>();
                //disables buttond for player input
                canvas.GetComponent<GraphicRaycaster>().enabled = false;
            }
        }

        //wait 1 second
        yield return new WaitForSeconds(1f);
    }
    public void CheckInput()
    {
        //check the button pressed by player matches button
        //at equivilent index in GamesButtonsPressed list

        //the lists do not have the same number of entries
        if (GameButtonsPressed.Count != playerButtonsPressed.Count)
        {
            //playerwins is set to false
            playerwins = false;
            //calls winCondition
            winCondition();
        }
        //else
        else
        {
            //Sort both lists
            GameButtonsPressed.Sort();
            playerButtonsPressed.Sort();
        }
        //Go through lists and determine if buttons pressed at each index are the same
        for (int i = 0; i < GameButtonsPressed.Count; i++)
        {
            if (playerButtonsPressed[i] != GameButtonsPressed[i])
            {
                //playerwins is set to false
                playerwins = false;
                //calls winCondition
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
            currentRound += 1;

            enemyHealth -= 1;

            numberOfPresses += 1;

            if (currentRound == 2)
            {
                Invoke("HealthToZero", time);
                Invoke("Round2", time);
                //calls startRound method
                StartRound();
            }
            else if (currentRound == 3)
            {

                Invoke("HealthToOne", time);
                Invoke("Round3", time);
                //calls startRound method
                StartRound();
            }
            else if (currentRound == 4)
            {
                Invoke("HealthToZero", time);

                //load the next scene
                LoadGameScene();
            }
            //if playerwins is equal to false
            else if (playerwins == false)
            {
                //subtract 1 from player health
                playerHealth -= 1;

                if (playerHealth == 2)
                {
                    Invoke("PlayerHealthToTwo", time);
                    //calls startRound method
                    StartRound();
                }
                else if (playerHealth == 1)
                {
                    Invoke("PlayerHealthToOne", time);

            
                    //calls startRound method
                    StartRound();
                }
                //if player health is less than or equal to 0
                if (playerHealth <= 0)
                {
                    Invoke("PlayerHealthToZero", time);

                    //turn on game over menu
                    Invoke("TurnOnGameOver", time);

                    //prints Game Over Meassage in the console
                    Debug.Log("Game Over");
                }
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