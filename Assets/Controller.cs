using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody2D systemController;
    PuckMovement puckMovement;
    public GameObject puck;
    public Vector2 destination;
    public Vector2 startingPoint;
    public Vector2 normalPoint;
    public Vector2 referenceVelocity;
    public float angle;
    public Vector2 referenceVector;
    public float deltaX;
    public float deltaY;
    public float predictedY;
    private Vector2 targetShot;
    private Vector2 targetPosition;
    private Vector2 AIVelocity;
    public float deltaTime;
    



 



    void Start()
    {
        systemController = gameObject.GetComponent<Rigidbody2D>();
        puckMovement = puck.GetComponent<PuckMovement>();

        normalPoint = new Vector2(-700,0);
        referenceVelocity = new Vector2(0,0);
        targetPosition = new Vector2(900,0);

        deltaX = 200;


        
  
    }



    
    void FixedUpdate()
    {

        if(puckMovement.currentPosition.x < -300 && puckMovement.currentPosition.x > -800)
        {
            //passing the value tho the method
            CalculateAngle(deltaX);
            //passing the value to the method
            CalculatepredictedY(deltaY);
            //passing the value to the method
            vectorshot(destination);

            movePuckX(deltaTime);
            movePuckY(deltaTime);

        }

        //Prevents overshooting
        if (predictedY > 650)
        {
            float deltaError = predictedY - 650;
            predictedY = 0;
            predictedY = 650 - deltaError;

        }
        else if (predictedY < -650)
        {
            float deltaError = -predictedY - 650;
            predictedY = 0;
            predictedY = 650 - deltaError;
        }



        destination = new Vector2(-600, predictedY);
        AIVelocity = new Vector2(AIVelocity.x, AIVelocity.y);
        //statement to move puck
        if(puckMovement.currentPosition.x < -400 && puckMovement.currentPosition.x > -1000 )
        {

            if (puckMovement.currentPosition.x < transform.position.x - 200 && puckMovement.currentPosition.y < 450 && puckMovement.currentPosition.y > -450)
            {
                startingPoint = Vector2.Lerp(transform.position, puckMovement.currentPosition, 0.2f);
                systemController.MovePosition(startingPoint);
            }
            else
            {
                systemController.velocity = AIVelocity;
            }

            
            

        }
        else
        {
            transform.position = normalPoint;
        }

 
        
    }
    //Prevents drifting of the puck
    private void OnCollisionEnter2D(Collision2D collision)
    {


        systemController.velocity = referenceVelocity;


    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (puckMovement.currentPosition.x > transform.position.x - 100 )
        {
            puckMovement.applyForce = true;
            puckMovement.aplliedForce = targetShot;
        }

        

    }

    //Method to calculate destination point
    float CalculatepredictedY(float deltaY)
    {
        if (puckMovement.currentVelocity.y > 0)
        {
            predictedY = puckMovement.currentPosition.y + deltaY;
        }
        else
        {
            predictedY = puckMovement.currentPosition.y - deltaY;
        }

        return predictedY;
    }
    //Method to calculate angle
    float CalculateAngle(float deltaX)
    {
        if(puckMovement.currentVelocity.y > 0)
        {
            referenceVector = new Vector2(0, 200);
        }
        else
        {
            referenceVector = new Vector2(0, -200);
        }
        
        angle = Vector2.Angle(referenceVector, puckMovement.currentVelocity);

        deltaY = deltaX / Mathf.Tan(angle*Mathf.Deg2Rad);

        return deltaY;
    }

    //function to calculate where the ball needs to be shot
    Vector2 vectorshot(Vector2 destination)
    {

        targetShot = -destination + targetPosition;
        return targetShot;
    }

    //Function to move the puck to the desired point

    float movePuckX(float deltaTime)
    {
        if(transform.position.x < -400)
        {
            AIVelocity.x = (2 *deltaX ) / deltaTime;
        }
        

        

        return AIVelocity.x;

        
    }

    float movePuckY(float deltaTime)
    {
        if(transform.position.x < -400)
        {
            AIVelocity.y = (2 * predictedY) / deltaTime;
        }
        

        return AIVelocity.y;
    }




}
