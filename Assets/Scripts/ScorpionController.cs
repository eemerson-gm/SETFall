/*
 *  FILE: ScorpionController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls the scorpion patrolling.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-02
 */
using UnityEngine;

/*
 *  NAME: Croc Controller
 *  PURPOSE: To patrol the scorpion back and forth across the screen.
 */
public class ScorpionController : MonoBehaviour
{

    //Defines the scorpion walking direction.
    public SpriteRenderer ScorpionRenderer;
    public float ScorpionSpeed = 4;
    public int ScorpionDirection = -1;

    void Start()
    {

        //Starts the scorpion turn timer.
        InvokeRepeating("ScorpionTurn", 4.0f, 4.0f);
        
    }

    void FixedUpdate()
    {

        //Moves the scorpion in the direction.
        transform.Translate(new Vector3(ScorpionDirection * ScorpionSpeed * Time.deltaTime, 0, 0));
        
    }

    /*
     *  FUNCTION: ScorpionTurn
     *  DESCRIPTION: Turns the scorpion around upon.
     *  PARAMETERS: N/A
     *  RETURNS: N/A
     */
    private void ScorpionTurn()
    {

        //Changes the direction of the scorpion.
        ScorpionDirection = -ScorpionDirection;
        ScorpionRenderer.flipX = !ScorpionRenderer.flipX;

    }
}
