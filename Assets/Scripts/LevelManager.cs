using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //player enter exit
    public bool player_enter, player_exit;


    //drone Spawn
    private bool spawned;

    public Transform[] drone_spawners;
    public GameObject drone;


    //Level Spawn 
    public GameObject level;
    public GameObject destroy_level;


   

    private void Awake()
    {
        player_enter = false;
        spawned = false;
    }





    private void Update()
    {
        //drone spawn
        if (!spawned)
        {
            if (player_enter)
            {
                for(int i = 0; i < drone_spawners.Length; i++)
                {
                    Instantiate(drone, drone_spawners[i].position, Quaternion.identity);
                    
                }
                //level spawn
                SpawnLevel();

                //set boolean
                spawned = true;
            }
            
        }

        //Destroy Level
        if (player_exit)
        {
            if (destroy_level != null)
            {
                Destroy(destroy_level);
            }
            
        }

    }

    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 100);
        GameObject obj=Instantiate(level, pos, Quaternion.identity);
        obj.GetComponent<LevelManager>().destroy_level = this.gameObject;


    }
    private void DestroyLevel()
    {
        Destroy(destroy_level);
    }


}
