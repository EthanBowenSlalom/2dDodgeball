using Player;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace Dodgeball
{
    public class Dodgeball : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerStats playerStats = collision.rigidbody.gameObject.GetComponent<PlayerStats>();
            
            //collision.GetContact(0).otherRigidbody

            //var player = transform.GetComponentInParent<Player>();

            playerStats.BallPickedup();

            Destroy(gameObject);
        }
    }
}
