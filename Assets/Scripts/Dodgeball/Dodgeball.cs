using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace Dodgeball
{
    public class Dodgeball : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Player player = collision.rigidbody.gameObject.GetComponent<Player>();
            
            //collision.GetContact(0).otherRigidbody

            //var player = transform.GetComponentInParent<Player>();

            player.BallPickedup();

            Destroy(gameObject);
        }
    }
}
