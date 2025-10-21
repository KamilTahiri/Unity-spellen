using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float upperLimit = 3.83f;
    public float lowerLimit = -3.83f;

    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed && transform.position.y < upperLimit)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }

        if (Keyboard.current.downArrowKey.isPressed && transform.position.y > lowerLimit)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
    }
}
