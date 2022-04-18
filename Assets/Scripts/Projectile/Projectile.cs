using UnityEngine;

namespace Projectile
{
    
    public class Projectile : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = transform.GetComponentInParent<Player>();

            player.AddHitCount();

            Destroy(gameObject);
        }
    }
}
