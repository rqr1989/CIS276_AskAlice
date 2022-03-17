using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundIndicator : MonoBehaviour
{
    //script to determine which round is indicated on screen
    public  GameObject Round1Panel;
    public  GameObject Round2Panel;
    public GameObject Round3Panel;
    public  bool isRound1 = true;
    public  bool isRound2 = false;
    public  bool isRound3 = false;
    public GameObject round1;
    public GameObject round2;
    public GameObject round3;
  // private string round;
 
    // Start is called before the first frame update
    void Start()
    {
        Round1Panel.SetActive(true);
        Round2Panel.SetActive(false);
        Round3Panel.SetActive(false);
        isRound1 = true;
        isRound2 = false;
        isRound3 = false;
    }
    //Round 1 method sets round 2 and 3 panels and text to inactive and activates round 1 text and panel
    public  void Round1()
    {
        Round1Panel.SetActive(true);
        Round2Panel.SetActive(false);
        Round3Panel.SetActive(false);
        isRound1 = true;
        isRound2 = false;
        isRound3 = false;
    }

    //Round 2 method sets round 1 and 3 panels and text to inactive and activates round 2 text and panel
   public  void Round2()
    {
        Round1Panel.SetActive(false);
        Round2Panel.SetActive(true);
        Round3Panel.SetActive(false);
        isRound1 = false;
        isRound2 = true;
        isRound3 = false;

    }
    //Round 3 method sets round 1 and 2 panels and text to inactive and activates round 3 text and panel
    public  void Round3()
    {
        Round1Panel.SetActive(false);
        Round2Panel.SetActive(false);
        Round3Panel.SetActive(true);
        isRound1 = false;
        isRound2 = false;
        isRound3 = true;
    }
}
