using Player;
using UnityEngine;

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
