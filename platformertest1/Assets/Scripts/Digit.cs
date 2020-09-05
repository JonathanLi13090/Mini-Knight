using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Digit : MonoBehaviour
{
    public Sprite[] Letters;
    public Sprite[] Numbers;

    public void SetDigit(char digit)
    {
        int ascii = (int)digit;
        if(ascii <= 57 && ascii >= 48)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Image>().sprite = Numbers[ascii - 48];
        }
        else if(ascii >= 65 && ascii <= 90)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Image>().sprite = Letters[ascii - 65];
        }
        else
        {
            GetComponent<Image>().enabled = false;
            
        }
    }
   
}
