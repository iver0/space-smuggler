using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPlate : MonoBehaviour
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
        if (col.gameObject == player)
        {
            playerScript.Armor = (playerScript.Armor < 75) ? playerScript.Armor + 25 : 100;
            Destroy(gameObject);
        }
    }
}
