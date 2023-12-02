using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool player_alive = true;

    public GameObject death_effect;


    public GameObject hand;
    public GameObject crooshiar;

    public GameObject GameOverMenu;

    public PauseMenu pm;

    public void Death()
    {

        if (player_alive)
        {
            //seet boolean
            player_alive = false;

            //disable pause menu
            pm.isGameOver = true;


            //particle effect
            Instantiate(death_effect, transform.position, Quaternion.identity);


            //disable player movent
            GetComponent<PlayerMovement>().enabled = false;

            hand.SetActive(false);
            crooshiar.SetActive(false);



            //cursor active
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //enable game over menu
            GameOverMenu.SetActive(true);

        }



    }
}
