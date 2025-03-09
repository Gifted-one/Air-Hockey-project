using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D player2D;
    public float moveHorizontal;
    public float moveVertical;

    public Vector2 movement;
    public Vector2 move;
    [SerializeField]
    public float Speed;
    private Vector2 start;
    private bool canMove;
    Countdown countdown;
    public GameObject countdownscript;
    


    void Start()
    {
        player2D = gameObject.GetComponent<Rigidbody2D>();
        countdown = countdownscript.GetComponent<Countdown>();
        

        
        
    }

    
    void Update()
    {
        if (countdown.CountInt < 1)
        {
            move = Input.mousePosition;
            move = Camera.main.ScreenToWorldPoint(move);
        }



        

        movement = Vector2.Lerp(transform.position, move, Speed);



        


    }

    private void FixedUpdate()
    {
        if(countdown.CountInt < 1)
        {
            player2D.MovePosition(movement);
        }
 
 






    }
}
