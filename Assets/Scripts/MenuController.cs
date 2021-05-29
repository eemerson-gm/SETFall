/*
 *  FILE: MenuController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls menus that load different game scenes.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-01
 */
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  NAME: Croc Controller
 *  PURPOSE: To allow menu functionality and scene loading.
 */
public class MenuController : MonoBehaviour
{

    /*
     *  FUNCTION: LoadScene
     *  DESCRIPTION: Loads the specified scene index upon button press.
     *  PARAMETERS: int level: The scene ID found in the build settings.
     *  RETURNS: N/A
     */
    public void LoadScene(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    /*
     *  FUNCTION: StopGame
     *  DESCRIPTION: Closes the game application.
     *  PARAMETERS: N/A
     *  RETURNS: N/A
     */
    public void StopGame()
    {
        Application.Quit();
    }

}
