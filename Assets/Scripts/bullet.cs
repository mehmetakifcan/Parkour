using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 100;

    public float lifetime = 5f;

    public float bullet_radius = 0.5f;
    public bool enemy_bullet = false;
    public LayerMask player_layer;
    public AudioClip hit_sounds;

    public GameObject hit_effect;

    private void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        //enemy bullet
        if (enemy_bullet)
        {
            if (Physics.CheckSphere(transform.position, bullet_radius, player_layer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }


        }




        
    }


    private void OnTriggerEnter(Collider other)
    {

        //if hit to enemy 
        if (other.CompareTag("enemy"))
        {
            GameObject enemy = other.transform.parent.gameObject;
            enemy.GetComponent<enemy>().healt -= 25f;
            enemy.GetComponent<AudioSource>().PlayOneShot(hit_sounds);
        }

        //hit
        Instantiate(hit_effect, transform.position, transform.rotation);
        Destroy(this.gameObject);




    }



}
