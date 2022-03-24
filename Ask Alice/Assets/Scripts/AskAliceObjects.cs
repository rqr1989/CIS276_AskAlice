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
      
        //runs button onClick event
        button.onClick.Invoke();

    }

    public void DeselectButton()
    {
        //sets buttonImage color back to original color
        buttonImage.color = originalColor;
    }
    public void AddButtonToPlayerPressedList()
    {
        AskAliceManager.playerPressedButtons.Add(button);// You already declare the button in your script so im just reusing that variable
    }
}
