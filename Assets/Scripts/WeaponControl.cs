using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject hand;


    public LayerMask obstacleLayer;
    public Vector3 offset;
    
    RaycastHit hit;


    public GameObject bullet;
    public Transform FirePoint;


    private float coolDown;
    public AudioClip gunshot;

    private void Update()
    {
        //look
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);
            

        }

        //cooldown
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        //shot

        if (Input.GetMouseButtonDown(0) && coolDown<=0)
        {
            //creat bullet
            Instantiate(bullet, FirePoint.position, transform.rotation);
            //reset cooldown
            coolDown = 0.33f;
            //sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot, 0.4f);

            //animation
            GetComponent<Animator>().SetTrigger("shot");
  
        }




    }

}
