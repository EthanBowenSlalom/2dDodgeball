using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace Projectile
{
    
    public class Projectile : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            /*
            Debug.Log("OnCollisionEnter2D! Dodgeball Collosion" + collision);

            foreach (ContactPoint2D contact in collision.contacts)
            {
                Debug.Log(contact.collider.name);
            }
            */

            var player = transform.GetComponentInParent<Player>();

            player.AddHitCount();

            Destroy(gameObject);
        }
    }
}
