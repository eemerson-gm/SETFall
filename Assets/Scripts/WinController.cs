/*
 *  FILE: WinController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls the win screen display.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-02
 */
using UnityEngine;
using TMPro;

/*
 *  NAME: Croc Controller
 *  PURPOSE: To update the end screen with result information.
 */
public class WinController : MonoBehaviour
{

    //Defines the winning text objects.
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextTime;
    public TextMeshProUGUI TextLives;

    void Start()
    {

        //Sets the text values to the in-game values.
        TextScore.text = "Score: " + GlobalController.GlobalScore.ToString();
        TextTime.text = "Time Left: " + Mathf.Floor(GlobalController.GlobalSeconds).ToString();
        TextLives.text = "Lives Left: " + GlobalController.GlobalLives.ToString();

        //Sets the game to not be continuable.
        GlobalController.GlobalContinue = false;

    }

}
