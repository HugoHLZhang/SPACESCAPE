using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollisionDetection : MonoBehaviour
{

    public PlayerStats playerStats;
    private void Start()
    {
        playerStats = PlayerStats.playerStats;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerStats.TakeDamage(15);
            FindObjectOfType<AudioManager>().Play("GettingHit");
            //Debug.Log("hit Wall!!");
        }

        //Debug.Log("hit !!");
    }


}