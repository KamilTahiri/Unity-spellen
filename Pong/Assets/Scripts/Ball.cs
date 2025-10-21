using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startingspeed;
    public float acceleration = 0.07f;
    public Rigidbody2D rb;

    void Start()
    {
        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 direction = rb.linearVelocity.normalized;

            rb.linearVelocity += direction * rb.linearVelocity.magnitude * acceleration;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "playerGoal")
        {
            GameManager.AddPointToOpponent();
            ResetBall();
        }
        else if (collision.gameObject.name == "opponentGoal")
        {
            GameManager.AddPointToPlayer();
            ResetBall();
        }
    }
    void ResetBall()
    {
        transform.position = Vector2.zero;

        float xVelocity = Random.value >= 0.5f ? 1f : -1f;
        float yVelocity = Random.Range(-1f, 1f);

        Vector2 direction = new Vector2(xVelocity, yVelocity).normalized;
        rb.linearVelocity = direction * startingspeed;
    }
}
