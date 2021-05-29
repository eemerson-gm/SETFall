/*
 *  FILE: VineController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls the vine swinging back and forth.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-01
 */
using UnityEngine;

/*
 *  NAME: Croc Controller
 *  PURPOSE: To swing the vine back and forth and calculate the grab position.
 */
public class VineController : MonoBehaviour
{

    //Defines the vine rotation direction.
    public float VineSpeed = 0.2f;
    public float VineRotation = 40;
    public int VineDirection = 1;
    public float VinePositionX = 0;
    public float VinePositionY = 0;
    public float VineLength = 6;

    void FixedUpdate()
    {

        //Updates the vine position.
        VinePositionX = VineLength * Mathf.Sin(transform.localEulerAngles.z * Mathf.Deg2Rad);
        VinePositionY = VineLength * -Mathf.Cos(transform.localEulerAngles.z * Mathf.Deg2Rad);

        //Rotates the vine back and forth.
        Vector3 TempRotation = transform.rotation.eulerAngles;
        TempRotation.z += VineSpeed * VineDirection * Time.deltaTime;
        transform.rotation = Quaternion.Euler(TempRotation);

        //Checks if the rotation has reached its peak and changes directions.
        if(VineDirection == 1)
        {
            if ((transform.localEulerAngles.z > (Mathf.Abs(VineRotation) - 1)) && (transform.localEulerAngles.z < (Mathf.Abs(VineRotation) + 1)))
            {
                VineRotation = -VineRotation;
                VineDirection = -1;
            }
        }
        else
        {
            if ((transform.localEulerAngles.z > (360 - Mathf.Abs(VineRotation) - 1)) && (transform.localEulerAngles.z < (360 - Mathf.Abs(VineRotation) + 1)))
            {
                VineRotation = -VineRotation;
                VineDirection = 1;
            }
        }

    }

}
