using UnityEngine;
using UnityEngine.InputSystem;

public class Opponent : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Transform ball;

    public float upperLimit = 3.83f;
    public float lowerLimit = -3.83f;
    
    void Update()
    {
        if (ball == null) return;

        if (ball.position.y > transform.position.y && transform.position.y < upperLimit)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else if (ball.position.y < transform.position.y && transform.position.y > lowerLimit)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }
}
