/*
 *  FILE: CrocController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls the crocodile object.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-01
 */
using UnityEngine;

/*
 *  NAME: Croc Controller
 *  PURPOSE: To open a close the mouth of the crocodile object.
 */
public class CrocController : MonoBehaviour
{

    //Defines the mouth open or closed variable.
    public Collider CrocCollider;
    public SpriteRenderer CrocSprite;
    public Sprite CrocSpriteOpen;
    public Sprite CrocSpriteClosed;
    public bool CrocOpen = false;

    void Start()
    {

        //Starts the crocadile mouth timer.
        InvokeRepeating("OpenCloseMouth", 0.0f, 2.0f);
        
    }

    /*
     *  FUNCTION: OpenCloseMouth
     *  DESCRIPTION: Toggles the crocodile's mouth open a closed upon running the script.
     *  PARAMETERS: N/A
     *  RETURNS: N/A
     */
    void OpenCloseMouth()
    {

        //Checks if the mouth is opened or closed.
        if(CrocOpen == true)
        {

            //Sets the croc mouth to be closed.
            CrocCollider.isTrigger = false;
            CrocSprite.sprite = CrocSpriteClosed;
            CrocOpen = false;

        }
        else
        {

            //Sets the croc mouth to be closed.
            CrocCollider.isTrigger = true;
            CrocSprite.sprite = CrocSpriteOpen;
            CrocOpen = true;

        }

    }

}
