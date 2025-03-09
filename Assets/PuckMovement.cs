using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;

public class PuckMovement : MonoBehaviour
{
    public Vector2 currentVelocity;
    public Vector2 currentPosition;
    public bool applyForce;
    public Vector2 aplliedForce;
    public float puckSpeed;
    public int Playerscore = 0;
    public int AIscore = 0;
    public TextMeshProUGUI playerscore;
    public TextMeshProUGUI aiscore;
    public Vector2 aiscored;
    public Vector2 aiscoreSpeed;
    public Vector2 playerscored;

    public Rigidbody2D Puck;



    void Start()
    {
        Puck = gameObject.GetComponent<Rigidbody2D>();
        aiscored = new Vector2(500, 0);
        aiscoreSpeed = new Vector2(0,0);
        playerscored = new Vector2(1000,0);
    }

    
    void Update()
    {

        
        


    }

    private void FixedUpdate()
    {
       
        currentPosition = transform.position;

        currentVelocity = Puck.velocity;

        if (applyForce == true) 
        {
            Puck.velocity = aplliedForce*puckSpeed;
        }

        applyForce = false;

        if (currentVelocity.magnitude > 3000)
        {
            Puck.velocity = Puck.velocity.normalized*3000;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.x < 1140 && transform.position.x > 1050)
        {
            AIscore++;
            aiscore.text = AIscore.ToString();
            transform.position = aiscored;
            Puck.velocity = aiscoreSpeed;

        }

        if (transform.position.x > -1140 && transform.position.x < -1000)
        {
            Playerscore++;
            playerscore.text = Playerscore.ToString();
            transform.position = -aiscored;
            Puck.velocity = playerscored;

        }
    }






}
