using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    GameObject player;
    Player playerScript;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player & playerScript.Health != 100)
        {
            playerScript.Health = (playerScript.Health < 75) ? playerScript.Health + 25 : 100;
            Destroy(gameObject);
        }
    }
}
