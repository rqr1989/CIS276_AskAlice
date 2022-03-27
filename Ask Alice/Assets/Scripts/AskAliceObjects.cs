using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AskAliceObjects : MonoBehaviour
{
    public Color selectedColor;
    private Color originalColor;
    public Button button;
    private Image buttonImage;
    public Button pressed;


    // Start is called before the first frame update
    private void Awake()
    {

        //finds value of buttonImage
        buttonImage = GetComponent<Image>();
        //
        button = GetComponent<Button>();
        //sets original color equal to buttonImage's color
        originalColor = buttonImage.color;
    }

public void SelectButton()
    {
        //sets buttonImage color to selected color
        buttonImage.color = selectedColor;

  
    }
  
    public void DeselectButton()
    {
        //sets buttonImage color back to original color
        buttonImage.color = originalColor;
    }
    public void AddButtonToPlayerList()
    {
       //add pressed button to list
        AskAliceManager.playerPressedButtons.Add(pressed);// add pressed button to list
        
    }
    public void ButtonClickIndicator()
    {
        //make the button change color and play sound effect when pressed by computer
    } 
}
