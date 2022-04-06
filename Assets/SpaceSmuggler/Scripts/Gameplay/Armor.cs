using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameObject.Find("Player") & Player.Instance.Armor != 100)
        {
            Player.Instance.Armor = (Player.Instance.Armor < 75) ? Player.Instance.Armor + 25 : 100;
            Destroy(gameObject);
        }
    }
}
