using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameObject.Find("Player") & Player.Armor != 100)
        {
            Player.Armor = (Player.Armor < 75) ? Player.Armor + 25 : 100;
            Destroy(gameObject);
        }
    }
}
