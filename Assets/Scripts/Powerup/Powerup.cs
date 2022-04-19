using System;
using Player;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = transform.GetComponentInParent<PlayerStats>();

        player.AddHitCount();

        

        Destroy(gameObject);
    }
}
