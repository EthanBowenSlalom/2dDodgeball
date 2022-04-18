using Player;
using UnityEngine;

namespace Powerups
{
    public class Powerup : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = transform.GetComponentInParent<PlayerStats>();

            player.AddHitCount();



            Destroy(gameObject);
        }
    }
}
