using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCollisionDetection : MonoBehaviour
{

    public PlayerStats playerStats;
    public GameObject player;
    public PlayerHUD hud;
    private void Start()
    {
        playerStats = PlayerStats.playerStats;
        player = PlayerController.instance;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerStats.TakeDamage(15);
            StartCoroutine(redScreen());
            //Debug.Log("hit Wall!!");
        }

        //Debug.Log("hit !!");
    }

    IEnumerator redScreen()
    {
        player.GetComponent<PlayerHUD>().FadeRedScreen();
        yield return new WaitForSeconds(0.3f);
        player.GetComponent<PlayerHUD>().FadeRedScreen();
    }
}