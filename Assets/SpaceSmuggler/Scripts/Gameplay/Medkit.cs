using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameObject.Find("Player") & Player.Health != 100)
        {
            Player.Health = (Player.Health < 75) ? Player.Health + 25 : 100;
            Destroy(gameObject);
        }
    }
}
