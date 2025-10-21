using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerScore = 0;
    public static int opponentScore = 0;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;

    private static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public static void AddPointToPlayer()
    {
        playerScore++;
        instance.UpdateScoreUI();
    }

    public static void AddPointToOpponent()
    {
        opponentScore++;
        instance.UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        playerScoreText.text = playerScore.ToString();
        opponentScoreText.text = opponentScore.ToString();
    }
}
