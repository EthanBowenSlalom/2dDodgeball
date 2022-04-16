using Player;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace Projectile
{
    
    public class Projectile : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = transform.GetComponentInParent<PlayerStats>();

            player.AddHitCount();

            Destroy(gameObject);
        }
    }
}
