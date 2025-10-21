using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletDespawner"))
        {
            Destroy(this.gameObject);
        }
    }
}
