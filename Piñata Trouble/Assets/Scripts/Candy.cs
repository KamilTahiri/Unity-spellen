using UnityEngine;

public class Candy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerCharacter")
        {
            GameManager.Instance.AddScore(1);

            Destroy(gameObject);
        }
    }
}
