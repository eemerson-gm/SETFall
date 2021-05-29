/*
 *  FILE: PlayerController.cs
 *  PROJECT: SETFall
 *  DESCRIPTION: This file contains the code that controls the controllable player in-game.
 *  PROGRAMMER: Eric Emerson
 *  FIRST VERSION: 2021-03-01
 */
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  NAME: Player Controller
 *  PURPOSE: To control the player and the state of the player and how they interact with the enviroment.
 */
public class PlayerController : MonoBehaviour
{

    //Defines the player movement variables.
    public AudioSource AudioJump;
    public AudioSource AudioHurt;
    public AudioSource AudioGold;
    public GameObject PlayerCamera;
    private float PlayerCameraZ1 = -10;
    private float PlayerCameraY1 = 3.5f;
    private float PlayerCameraR1 = 4.8f;
    private float PlayerCameraZ2 = -6.3f;
    private float PlayerCameraY2 = 8.2f;
    private float PlayerCameraR2 = 47;
    public GlobalController GameController;
    public Animator PlayerAnimator;
    public SpriteRenderer PlayerSprite;
    public Collider PlayerCollider;
    private float PlayerStartX = 0;
    private float PlayerStartY = 0;
    public float PlayerSpeed = 5;
    public float PlayerJump = 4;
    public float PlayerAccel = 40;
    public float PlayerGravity = 4;
    public float PlayerHspeed = 0;
    public float PlayerVspeed = 0;
    public bool PlayerGrounded = false;
    public bool PlayerVine = false;
    public bool PlayerRevine = false;
    public bool PlayerTar = false;
    public bool PlayerRetar = true;
    public GameObject PlayerVineObject;
    public GameObject PauseCanvas;

    void Start()
    {

        //Disables the pause menu.
        PauseCanvas.SetActive(false);

        //Sets the starting position of the player.
        PlayerStartX = transform.position.x;
        PlayerStartY = transform.position.y;
        
    }

    void FixedUpdate()
    {

        //Checks if the player is not on a vine.
        if (PlayerVine == false)
        {

            //Gets the player walking direction.
            int PlayerDirection = (Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A)));

            //Updates the horizontal speed of the player.
            PlayerHspeed = Mathf.MoveTowards(PlayerHspeed, (PlayerSpeed - (Convert.ToInt32(PlayerTar) * 2.5f)) * PlayerDirection, PlayerAccel * Time.deltaTime);

            //Moves the player in the direction.
            transform.Translate((Vector3.right * PlayerHspeed) * Time.deltaTime);

            //Checks if the player is on the ground.
            if (PlayerGrounded = IsGrounded())
            {

                //Resets the player vertical speed.
                PlayerVspeed = 0;

                //Allows the player to jump on the vine again.
                PlayerRevine = true;

                //Checks if the jump button is pressed.
                if (Input.GetKey(KeyCode.Space))
                {

                    //Plays the jump sound effect.
                    AudioJump.Play();

                    //Applies vertical speed to the player.
                    PlayerVspeed = PlayerJump;
                    PlayerRetar = true;

                }

            }
            else
            {

                //Applies gravity to the player vertical speed.
                PlayerVspeed -= PlayerGravity * Time.deltaTime;

            }

            //Moves the player in the direction.
            transform.Translate((Vector3.up * PlayerVspeed) * Time.deltaTime);

        }
        else
        {

            //Gets the position variables from the vine.
            VineController vine = PlayerVineObject.GetComponent<VineController>();

            //Sets the position of the player to the vine position.
            float vinex = PlayerVineObject.transform.position.x + vine.VinePositionX;
            float viney = PlayerVineObject.transform.position.y + vine.VinePositionY;
            transform.position = new Vector3(vinex, viney);

            //Checks if the jump button is pressed.
            if (Input.GetKey(KeyCode.Space))
            {

                //Plays the jump sound effect.
                AudioJump.Play();

                //Applies vertical speed to the player.
                PlayerVspeed = PlayerJump;

                //Disables the vine collision.
                PlayerVine = false;
                PlayerRevine = false;
                PlayerRetar = true;

            }

        }

        //Resets the player tar state.
        PlayerTar = false;

    }

    void Update()
    {

        //Checks if the pause button has been pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas.activeSelf == false)
            {
                Time.timeScale = 0f;
                PauseCanvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                PauseCanvas.SetActive(false);
            }
        }

        //Checks if the player is on a vine.
        if (PlayerVine == true)
        {

            //Approaches the looking down position of the camera.
            float CameraZ = Mathf.Lerp(PlayerCamera.transform.position.z, PlayerCameraZ2, 2f * Time.deltaTime);
            float CameraY = Mathf.Lerp(PlayerCamera.transform.position.y, PlayerCameraY2, 2f * Time.deltaTime);
            Vector3 TempRotation = PlayerCamera.transform.rotation.eulerAngles;
            TempRotation.x = Mathf.Lerp(TempRotation.x, PlayerCameraR2, 2f * Time.deltaTime);
            PlayerCamera.transform.rotation = Quaternion.Euler(TempRotation);

            //Updates the position of the camera.
            PlayerCamera.transform.position = new Vector3(0, CameraY, CameraZ);

        }
        else
        {

            //Approaches the looking down position of the camera.
            float CameraZ = Mathf.Lerp(PlayerCamera.transform.position.z, PlayerCameraZ1, 2f * Time.deltaTime);
            float CameraY = Mathf.Lerp(PlayerCamera.transform.position.y, PlayerCameraY1, 2f * Time.deltaTime);
            Vector3 TempRotation = PlayerCamera.transform.rotation.eulerAngles;
            TempRotation.x = Mathf.Lerp(TempRotation.x, PlayerCameraR1, 2f * Time.deltaTime);
            PlayerCamera.transform.rotation = Quaternion.Euler(TempRotation);

            //Updates the position of the camera.
            PlayerCamera.transform.position = new Vector3(0, CameraY, CameraZ);

        }

        //Checks if the player is moving.
        if (PlayerHspeed != 0)
        {

            //Changes the flip of the player sprite.
            PlayerSprite.flipX = (PlayerHspeed < 0);

        }

        //Checks if the player is on the ground.
        if (IsGrounded())
        {

            //Stops the jumping animation with the animator.
            PlayerAnimator.SetBool("Jumping", false);

            //Checks if the walking animation should play.
            if (Mathf.Abs(PlayerHspeed) >= (PlayerSpeed / 2))
            {

                //Plays the walking animation with the animator.
                PlayerAnimator.SetBool("Walking", true);

            }
            else
            {

                //Plays the idle animation with the animator.
                PlayerAnimator.SetBool("Walking", false);

            }

        }
        else
        {

            //Plays the jumping animation with the animator.
            PlayerAnimator.SetBool("Jumping", true);

        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {

        //Checks the tag of the collision.
        switch (collision.gameObject.tag)
        {

            //Checks if the gameobject is tagged as death.
            case "Death":

                //Plays the hurt sound effect.
                AudioHurt.Play();

                //Teleports the player back to the start.
                transform.position = new Vector3(PlayerStartX, PlayerStartY);

                //Removes the lives and score from the player.
                GameController.UpdateLives(1);

                break;

            //Checks if the gameobject is tagged as vine.
            case "Vine":

                //Checks if the player can grab a vine.
                if(PlayerRevine == true)
                {

                    //Sets the player to be holding onto a vine.
                    PlayerVine = true;

                    //Sets the vine game object.
                    PlayerVineObject = collision.gameObject;

                }

                break;

            //Checks if the gameobject is tagged as log.
            case "Log":

                //Plays the hurt sound effect.
                AudioHurt.Play();

                //Removes the score from the player.
                UnityEngine.Random.State oldstate = UnityEngine.Random.state;
                GameController.UpdateScore(-UnityEngine.Random.Range(100, 301));
                UnityEngine.Random.state = oldstate;

                //Destroys the log.
                collision.gameObject.SetActive(false);

                break;

            //Checks if the gameobject is tagged as gold.
            case "Gold":

                //Plays the gold sound effect.
                AudioGold.Play();

                //Adds to the score.
                GameController.UpdateScore(2000);

                //Deactivates the gold.
                collision.gameObject.SetActive(false);

                break;

            //Checks if the gameobject is tagged finish.
            case "Finish":

                //Increments the level index.
                GlobalController.GlobalLevel += 1;

                //Checks if the levels have been complete.
                if (GlobalController.GlobalLevel > 5)
                {

                    //Changes to the win screen.
                    SceneManager.LoadScene("WinScene");

                }
                else
                {

                    //Reloads the level.
                    SceneManager.LoadScene("LevelScene");

                }

                break;
        }
    }

    /*
     *  FUNCTION: IsGrounded
     *  DESCRIPTION: Checks if the player is on the ground using a raycast collision.
     *  PARAMETERS: N/A
     *  RETURNS: bool: True if the raycast collides with a non-trigger collider.
     */
    private bool IsGrounded()
    {

        //Gets a ray to check for ground collision.
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -Vector3.up);

        //Checks if the raycast hit a collision.
        if (Physics.Raycast(ray, out hit))
        {

            //Checks if the hit distance is within range.
            if (hit.distance <= PlayerCollider.bounds.extents.y + 0.01f) {

                //Checks if the collider is tar.
                if(hit.collider.tag == "Tar")
                {
                    if (PlayerRetar == true) {

                        //Removes the score from the player.
                        UnityEngine.Random.State oldstate = UnityEngine.Random.state;
                        GameController.UpdateScore(-UnityEngine.Random.Range(100, 301));
                        UnityEngine.Random.state = oldstate;

                    }
                    PlayerRetar = false;
                    PlayerTar = true;
                }
                else
                {
                    PlayerTar = false;
                    PlayerRetar = true;
                }

                //Checks if the collision is a trigger.
                if (hit.collider.isTrigger == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

        }
        return false;
    }
}
