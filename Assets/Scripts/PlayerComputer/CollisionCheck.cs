using UnityEngine;

namespace PlayerComputer
{
    public class CollisionCheck : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}
