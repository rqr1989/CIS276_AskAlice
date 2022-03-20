using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthCard3;
    public GameObject healthCard2;
    public GameObject healthCard1;
    public Color selectedColor;
  

    public Image health3;
    public Image health2;
    public Image health1;
    void Awake()
    {
        healthCard3.SetActive(true);
        healthCard2.SetActive(true);
        healthCard1.SetActive(true);

        health3 = GetComponent<Image>();


        health2 = GetComponent<Image>();

    
        health1 = GetComponent<Image>();
       
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayerHealthToTwo()
    {
        //turns health 3 read
        health3.color = selectedColor;
        //wait 1 second
        yield return new WaitForSeconds(1f);
        //then makes the health 3 image inactive
        healthCard3.SetActive(false);
    }

    IEnumerator PlayerHealthToOne()
    {
        healthCard3.SetActive(false);

        health2.color = selectedColor;

        yield return new WaitForSeconds(1f);

        healthCard2.SetActive(false);

    }

    IEnumerator PlayerHealthToZero()
    {
        healthCard3.SetActive(false);

        healthCard2.SetActive(false);

        health1.color = selectedColor;

        yield return new WaitForSeconds(1f);

        healthCard1.SetActive(false);
       
        health1.color = selectedColor;

        yield return new WaitForSeconds(1f);

        healthCard1.SetActive(false);
    }

}
