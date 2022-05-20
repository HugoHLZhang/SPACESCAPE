using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollisionDetection : MonoBehaviour
{


    //[SerializeField] public GameObject Player;

    private BoxCollider ShotCollider;
    public PlayerStats playerStats;
    private Collider collision;

    private void Start()
    {
        playerStats = PlayerStats.playerStats;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            playerStats.TakeDamage(15);
            Debug.Log("hit Wall!!");
        }

        Debug.Log("hit !!");
    }
}