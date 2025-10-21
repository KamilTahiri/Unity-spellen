using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D powerUpCollider;

    [HideInInspector]
    public bool isPresent = false;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        powerUpCollider = GetComponent<Collider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            HidePowerUp();
        }
    }

    private void HidePowerUp()
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;
        if (powerUpCollider != null)
            powerUpCollider.enabled = false;
    }

    private void ShowPowerUp()
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = true;
        if (powerUpCollider != null)
            powerUpCollider.enabled = true;
    }

    public void StartSpawnCheck(float percentageChance)
    {
        if (!isPresent)
            StartCoroutine(SpawnRoutine(percentageChance));
    }

    private IEnumerator SpawnRoutine(float percentageChance)
    {
        while (!isPresent)
        {
            yield return new WaitForSeconds(1f);
            float roll = Random.Range(0f, 100f);
            if (roll <= percentageChance)
            {
                float xPos = Random.Range(-11.206f, 11.206f);
                float yPos = -3.516f;
                transform.position = new Vector3(xPos, yPos, transform.position.z);
                isPresent = true;
                ShowPowerUp();
                yield break;
            }
        }
    }
}