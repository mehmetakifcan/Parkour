using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;

    public GameObject pausemenu_obj;
    public bool isGameOver = false;

    public AudioSource music;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (!isGamePaused)
            {
                
                Pausegame();

            }
            else
            {
                ResumeGame();
            }


        }


    }
    private void Pausegame()
    {
        //set time scale
        Time.timeScale = 0;
        //music ğause
        music.Pause();


        //disavble playermovement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;

        //set cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;



        //pause menu
        pausemenu_obj.SetActive(true);
        //set boolean
        isGamePaused = true;
    }
    private void ResumeGame()
    {
        //set time scale
        Time.timeScale = 1;

        //music resume
        music.UnPause();

        //enable playermovement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;

        //set cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        //pause menu
        pausemenu_obj.SetActive(false);


        //set boolean
        isGamePaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
