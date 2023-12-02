using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if playerfall to lava
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().Death();
        }

    }
}
