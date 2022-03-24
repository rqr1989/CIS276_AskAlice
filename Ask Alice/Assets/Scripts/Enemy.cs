using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject healthHeart3;
    public GameObject healthHeart2;
    public GameObject healthHeart1;
    public Color selectedColor;
    
    private Color originalColor;
    
    public Image enemyImage;

    // Start is called before the first frame update
    void Awake()
    {
        healthHeart3.SetActive(true);
        healthHeart2.SetActive(true);
        healthHeart1.SetActive(true);
        enemyImage = GetComponent<Image>();

     //originalColor = enemyImage.color;
   

    }

   

    public void HealthToTwo()
    {
        //removes third heart from screen
        healthHeart3.SetActive(false);

        //still shows first two hearts
        healthHeart2.SetActive(true);
        healthHeart1.SetActive(true);

    }
    public void HealthToOne()
    {
        //removes third heart from screen
        healthHeart3.SetActive(false);

        //removes second heart from screen
        healthHeart2.SetActive(false);

        //keeps 1rst heart  scroneen
        healthHeart1.SetActive(true);
    }
    public void HealthToZero()
    {
        //removes third heart from screen
        healthHeart3.SetActive(false);

        //removes second heart from screen
        healthHeart2.SetActive(false);

        //removes 1rst heart  from screen
        healthHeart1.SetActive(false);
    }

    //makes the enemy image flash Red for a second to demonstrate taking damage
    IEnumerator EnemyInjury()
    {
           //set enemyImage to selected color
            enemyImage.color = selectedColor;

        //wait 1 second
        yield return new WaitForSeconds(1f);

        //set enemy image back to original color
        enemyImage.color = originalColor;
    }

    
}
