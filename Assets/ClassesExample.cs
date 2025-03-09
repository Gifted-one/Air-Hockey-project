using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassesExample : MonoBehaviour
{
    int positive_number = 0;
    public TMP_InputField positive_number_inputfield;


    //dispay words
    string words = "";
    public TextMeshProUGUI display_words;


    //button function
    public void Convert()
    {
        positive_number = Int32.Parse(positive_number_inputfield.text);
        display_words.text = ConvertNumbersToWords(positive_number);
    }


    string ConvertNumbersToWords(int number)
    {
        if(number < 10)
        {
            getTheUnits(number);
        }


        return words;
    }

    string getTheUnits(int number)
    {
        
        return words;
    }
}
