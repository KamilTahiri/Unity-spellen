using UnityEngine;

public class Invincibility : PowerUp
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        GameManager.Instance.SetCanTakeDamageTemp(false, 3f);
        isPresent = false;
        StartSpawnCheck(GameManager.Instance.invincibilityPercentageChance);
    }

    void Start()
    {
        StartSpawnCheck(GameManager.Instance.invincibilityPercentageChance);
    }
}
