/*
 *  FILE: StartController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls the continue game option.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-02
 */
using UnityEngine;
using UnityEngine.UI;

/*
 *  NAME: Croc Controller
 *  PURPOSE: To allow the option of continuing the game after pausing and returning to menu.
 */
public class StartController : MonoBehaviour
{

    //Defines the continue button variable.
    public Button ContinueButton;

    void Start()
    {

        //Initializes the random seed.
        Random.InitState(1234);

        //Checks if the continue button should be interactable.
        if (GlobalController.GlobalContinue == true)
        {

            //Sets the continue button to be interactable.
            ContinueButton.interactable = true;

        }
        
    }

    /*
     *  FUNCTION: ResetGlobals
     *  DESCRIPTION: Resets the global values upon starting a new game.
     *  PARAMETERS: N/A
     *  RETURNS: N/A
     */
    public void ResetGlobals()
    {

        //Resets the values of the game.
        GlobalController.GlobalScore = 2000;
        GlobalController.GlobalLives = 3;
        GlobalController.GlobalSeconds = 50;
        GlobalController.GlobalLevel = 1;
        GlobalController.GlobalContinue = false;

    }

}
