using UnityEngine;

public class ScoreMultiplier : PowerUp
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        GameManager.Instance.SetScoreMultiplierTemp(2f, 5f);
        isPresent = false;
        StartSpawnCheck(GameManager.Instance.scoreMultiplierPercentageChance);
    }

    void Start()
    {
        StartSpawnCheck(GameManager.Instance.scoreMultiplierPercentageChance);
    }
}
