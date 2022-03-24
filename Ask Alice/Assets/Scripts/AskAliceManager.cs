using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Then on your AskAliceObjects script you could have a function similar to something like this:
 
   // In your inspector, click on your button, go to the onClickEvents, add an event, drag your button into the field, select the event -> AskAliceObjects->AddButtonToPlayerPressedList
   // This will also require you to remove the button.Onclick.Invoke(); from "Select Button" since that
   // would make the askAliceManager add the buttons to the player's list while the AI was pressing the buttons before the player gets a turn.
    

public class AskAliceManager : MonoBehaviour
{
    //round 1 mini boss is white rabbit, if player wins he is defeated els player takes damage, lose three times and its game over
    public string gameSceneName;
    public string MainMenu;
    public bool playerwins; //boolean to determine if player won

    public int enemyHealth = 3;  //white Rabit Health
   
    public int playerHealth = 3;  //player health

    public List<AskAliceObjects> allButtons = new List<AskAliceObjects>();
    private  List<Button> GameButtonsPressed = new List<Button>();
   public static List<Button> playerPressedButtons;
    public List<Button> playerButtonsPressed;

//public Button tophat;
   // public Button rightTeaCup;
   // public Button pocketWatch;
 //   public Button lockAndKey;


    private int numberOfPresses = 3;
    int playerpresses = 0;
    int currentRound = 1;
    public float time = 1f;
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
        for (int i = 0; i < GameButtonsPressed.Count; i++)
        {
            //calls 
            Invoke("AddButtonToPlayerPressedList", time);

        }
            //if the player has pressed 4 buttons
            if (playerpresses == numberOfPresses)
            {
                //find canvas in scene
                Canvas canvas = FindObjectOfType<Canvas>();
                //disables buttond for player input
                canvas.GetComponent<GraphicRaycaster>().enabled = false;
            }
        

        //wait 1 second
        yield return new WaitForSeconds(1f);
    }
   
        public void CheckInput()
        { 
        //check the button pressed by player matches button
        //at equivilent index in GamesButtonsPressed list
      
        //the lists do not have the same number of entries
            if(GameButtonsPressed.Count != playerButtonsPressed.Count)
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
        for (int i =0; i<GameButtonsPressed.Count; i++)
        {
            if(playerButtonsPressed[i] != GameButtonsPressed[i])
            {
                //playerwins is set to false
                playerwins = false;
                //calls winCondition
                winCondition();
            }
            else
            {
                playerwins = true;
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
        if(playerwins == true)
        {
            //add 1 to currentRound
            currentRound += 1;
            //subtract 1 from enemy health
            enemyHealth -= 1;
            if(currentRound == 2)
            {
                //calls HealthToTwo method form Enemy class
                Invoke("PlayerHealthToTwo", time);

                //calls Round2 method from Roubd Indicator class
                Invoke("Round2",time);

                //sets number pf presses to 4
                numberOfPresses += 1;

               //calls start round method
                StartRound();
            }
             else if(currentRound == 3)
            {

                Invoke("PlayerHealthToOne", time);
                //calls Round3 method from roundIndicator class
                Invoke("Round3",time);
                //ups number of pressed to 5
                numberOfPresses += 1;
                //calls startRound method
                StartRound();
            }
            else if (currentRound==4)
            {
                Invoke("PlayerHealthToZero", time);
                //load the next scene
                LoadGameScene();
            }


        }
        //if playerwins is equal to false
        else if (playerwins == false)
        {
            //subtract 1 from player health
            playerHealth -= 1;

            if(playerHealth == 2)
            {
                Invoke("PlayerHealthToTwo", time);
            }
            else if(playerHealth ==1)
            {
                Invoke("PlayerHealthToOne", time);
            }
            //if player health is less than or equal to 0
            if(playerHealth <= 0)
            {
                Invoke("PlayerHealthToZero", time);

                //turn on game over menu
                Invoke("TurnOnGameOver", time);

                //prints Game Over Meassage in the console
                Debug.Log("Game Over");

               
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
    public void AddToList(Button b, int i)
    {
        if (i < GameButtonsPressed.Count)
            playerButtonsPressed.Add(b);
    }
  
}



