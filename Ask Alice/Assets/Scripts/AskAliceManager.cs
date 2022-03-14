using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AskAliceManager : MonoBehaviour
{

    public List<AskAliceObjects> allButtons = new List<AskAliceObjects>();
    private  List<Button> GameButtonsPressed = new List<Button>();
    private List<Button> playerButtonsPressed = new List<Button>();
    private int numberOfPresses = 4;
    private int buttonCheck = 0;
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
}
//check the button pressed by player matches button
//at equivilent index in GamesButtonsPressed list
// if player wins start new round
//else player must retry or give up
//round 1 mini boss is white rabbit, if player wins he is defeated els player takes damage, lose three times and its game over

//2nd round should have 6 potential buttons and 6 button presses
//round 2 mini boss is mad hatter, if player wins he is defeated else player takes damage, lose three times and its game over

//Round three will have 8 buttons and 8 button presses
//round 3 mini boss is The Queen of Hearts Shadow if player wins he is defeated else player takes damage, lose three times and its game over