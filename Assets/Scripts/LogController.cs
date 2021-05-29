/*
 *  FILE: LogController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls the rolling logs.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-01
 */
using UnityEngine;

/*
 *  NAME: Log Controller
 *  PURPOSE: To move the rolling logs to the left of the screen.
 */
public class LogController : MonoBehaviour
{

    void FixedUpdate()
    {

        //Moves the logs to the left.
        transform.position -= (Vector3.right * 2 * Time.deltaTime);
        transform.Rotate(new Vector3(0, 2, 0));
        
    }

}
