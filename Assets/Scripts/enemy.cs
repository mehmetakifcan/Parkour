using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float follow_distance = 10f;
    public float speed = 10f;
    private Transform player;

    public GameObject mesh;


    public float healt = 100f;

    public GameObject bullet;

    public AudioClip death_sounds;

    private float cooldown = 2f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }

    private void FollowPlayer()
    {   //look to player
        transform.LookAt(player.position);

        //move to player

        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.Translate(transform.forward * Time.deltaTime*speed*-1);
        }
        else
        {
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed);
            
        }
    }

    private void Shot()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
            //shot

            mesh.GetComponent<Animator>().SetTrigger("shot");

            Instantiate(bullet, transform.position, transform.rotation);

            
            
        }
    }


    private void Death()
    {
        if (healt <= 0)
        {
            //play SOund effect
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sounds,0.50f);

            Destroy(this.gameObject);
        }
    }

}
