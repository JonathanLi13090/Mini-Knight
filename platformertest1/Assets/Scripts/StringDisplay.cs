using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringDisplay : MonoBehaviour
{
    public Digit[] Digits;
    public string text = "LIFE";
    // Start is called before the first frame update

    private void Start()
    {
        DisplayText(text);
    }

    public void DisplayText(string text)
    {
        for(int i = 0; i < Digits.Length; i += 1)
        {
            if(text.Length > i)
            {
                Digits[i].SetDigit(text[i]);
            }
            else
            {
                Digits[i].SetDigit(' ');
            }
        }
    }
}
