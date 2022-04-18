using System;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = transform.GetComponentInParent<Player>();

        player.AddHitCount();

        

        Destroy(gameObject);
    }
}
