/*
 *  FILE: GlobalController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls global variables and game mechanics.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-01
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
 *  NAME: Global Controller
 *  PURPOSE: To store global variables from scene to scene and generate the procedural terrain objects.
 */
public class GlobalController : MonoBehaviour
{

    //Defines the score and time variables.
    static public int GlobalScore = 2000;
    static public int GlobalLives = 3;
    static public float GlobalSeconds = 50;
    static public int GlobalLevel = 1;
    static public bool GlobalContinue = false;
    static public int GlobalTerrain = 0;
    static public int GlobalObstacle = 0;

    //Defines the text overlay and game values.
    public AudioSource Music;
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextTime;
    public TextMeshProUGUI TextLives;
    public GameObject[] TerrainList = new GameObject[3];
    public GameObject[] ObstacleList = new GameObject[3];
    public float GlobalTerrainX = 0;
    public float GlobalTerrainY = 0;
    public float GlobalObstacleX = 8.0f;
    public float GlobalObstacleY = 1.1f;

    void Start()
    {

        //Updates the score and lives overlay.
        UpdateScore(0);
        UpdateLives(0);

        //Generates random indexes for terrain and obstacle.
        int TerrainIndex = Random.Range(-1, 3);
        int ObstacleIndex = Random.Range(-1, 3);

        //Checks if the game is not being continued.
        if(GlobalContinue == false)
        {

            //Checks if the index is not invalid.
            if (TerrainIndex != -1)
            {
                Instantiate(TerrainList[TerrainIndex], new Vector3(GlobalTerrainX, GlobalTerrainY, 0), Quaternion.identity);
            }
            if (ObstacleIndex != -1)
            {
                Instantiate(ObstacleList[ObstacleIndex], new Vector3(GlobalObstacleX, GlobalObstacleY, 0), Quaternion.identity);
            }

            //Sets the index values to the values generated.
            GlobalTerrain = TerrainIndex;
            GlobalObstacle = ObstacleIndex;

        }
        else
        {

            //Creates the obstacles based on the continue values.
            if (GlobalTerrain != -1)
            {
                Instantiate(TerrainList[GlobalTerrain], new Vector3(GlobalTerrainX, GlobalTerrainY, 0), Quaternion.identity);
            }
            if (GlobalObstacle != -1)
            {
                Instantiate(ObstacleList[GlobalObstacle], new Vector3(GlobalObstacleX, GlobalObstacleY, 0), Quaternion.identity);
            }

            //Resets the global continue.
            GlobalContinue = false;

        }
        
    }

    void Update()
    {

        //Checks if the timer has reached the finish.
        if(GlobalSeconds > 0)
        {

            //Removes a frame time from the timer.
            GlobalSeconds -= Time.deltaTime;
            TextTime.text = "Timer: " + Mathf.Floor(GlobalSeconds).ToString();

        }
        else
        {

            //Changes to the game over scene.
            SceneManager.LoadScene("GameOver");

        }
        
    }

    /*
     *  FUNCTION: UpdateScore
     *  DESCRIPTION: Updates the score text to display the added score value.
     *  PARAMETERS: int score: The score amount to increase by.
     *  RETURNS: N/A
     */
    public void UpdateScore(int score)
    {

        //Updates the score text.
        GlobalScore += score;
        TextScore.text = "Score: " + GlobalScore.ToString();

    }

    /*
     *  FUNCTION: UpdateLives
     *  DESCRIPTION: Updates the lives text to display the subtracted lives count.
     *  PARAMETERS: int lives: The amount of lives to subtract.
     *  RETURNS: N/A
     */
    public void UpdateLives(int lives)
    {

        //Updates the lives text.
        GlobalLives -= lives;
        TextLives.text = "Lives : " + GlobalLives.ToString();

        //Updates the player score.
        UpdateScore(-500 * lives);

        //Checks if the player is out of lives.
        if(GlobalLives <= 0)
        {

            //Changes the scene to game over.
            SceneManager.LoadScene("GameOver");

            //Sets the game to not be continueable.
            GlobalContinue = false;

        }

    }

    /*
     *  FUNCTION: SetContinuable
     *  DESCRIPTION: Sets the global continue value to true (used for UI buttons).
     *  PARAMETERS: N/A
     *  RETURNS: N/A
     */
    public void SetContinueable()
    {

        //Sets the game to be continueable.
        GlobalContinue = true;

    }

}
