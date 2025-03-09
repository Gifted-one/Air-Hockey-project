using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public GameObject countdown;
    public float countdownCount;
    public TextMeshProUGUI count;
    public int CountInt;
    public TextMeshProUGUI MoveCursor;


    void Start()
    {
        countdown.SetActive(true);
        

    }

    
    void Update()
    {
       
    }
    public void FixedUpdate()
    {
        if(countdownCount >= 1)
        {
            
            countdownCount -= Time.fixedDeltaTime;
            CountInt = (int)countdownCount;
            count.text = CountInt.ToString();
            MoveCursor.text = "Move cursor to centre of puck";

        }
        else if (CountInt == 0)
        {
            countdownCount -= Time.fixedDeltaTime*2;
            CountInt = (int)countdownCount;
            count.text = "Start!";
        }
        else
        {
            countdown.SetActive(false);
        }



    }


}
