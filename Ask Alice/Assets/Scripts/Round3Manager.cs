using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round3Manager : MonoBehaviour
{
    public List<AskAliceObjects> allButtons = new List<AskAliceObjects>();
    private List<Button> GameButtonsPressed = new List<Button>();
    private List<Button> playerButtonsPressed = new List<Button>();
    private int numberOfPresses = 8;
    private int buttonCheck = 0;
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
}