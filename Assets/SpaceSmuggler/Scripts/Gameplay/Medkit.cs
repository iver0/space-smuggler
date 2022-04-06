using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameObject.Find("Player") & Player.Instance.Health != 100)
        {
            Player.Instance.Health = (Player.Instance.Health < 75) ? Player.Instance.Health + 25 : 100;
            Destroy(gameObject);
        }
    }
}
