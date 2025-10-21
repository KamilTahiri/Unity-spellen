using UnityEngine;

public class Pinata : MonoBehaviour
{
    public Vector2 startForce;
    public Rigidbody2D rb;

    public GameObject candyPrefab;
    public GameObject nextPinata;

    void Start()
    {
        rb.AddForce(startForce, ForceMode2D.Impulse);
    }

    private void SpawnCandy()
    {
        Instantiate(candyPrefab, transform.position, Quaternion.identity);
    }

    public void Split()
    {
        if (nextPinata != null)
        {
            GameObject pinata1 = Instantiate(nextPinata, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject pinata2 = Instantiate(nextPinata, rb.position + Vector2.left / 4f, Quaternion.identity);

            pinata1.GetComponent<Pinata>().startForce = new Vector2(2f, 5f);
            pinata2.GetComponent<Pinata>().startForce = new Vector2(-2f, 5f);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            SpawnCandy();
            Split();
            Destroy(collision.gameObject);
        }
    }
}
