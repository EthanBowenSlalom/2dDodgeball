using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace Projectile
{

    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        public static int hitCount = 0;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter2D! Dodgeball Collosion" + collision);

            foreach (ContactPoint2D contact in collision.contacts)
            {
                Debug.Log(contact.collider.name);
            }

            hitCount++;
            Destroy(gameObject);

        }
    }
}
