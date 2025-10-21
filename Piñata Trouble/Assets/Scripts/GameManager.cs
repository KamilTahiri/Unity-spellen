using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float currentScore;
    public float highScore;
    public float scoreMultiplier;

    public float invincibilityPercentageChance;
    public float scoreMultiplierPercentageChance;

    public bool hardMode;
    public bool canTakeDamage;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    private float multiplierEndUnscaledTime = 0f;
    private float canTakeDamageUnscaledTime = 0f;

    public GameObject pinataPrefab;
    private int pinataCount = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        UpdateScoreUI();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameplayScene")
        {
            ResetGame();

            if (hardMode)
            {
                invincibilityPercentageChance = 1;
                scoreMultiplierPercentageChance = 3;
            }
            else
            {
                invincibilityPercentageChance = 5;
                scoreMultiplierPercentageChance = 7;
            }
        }

        currentScoreText = GameObject.FindWithTag("CurrentScoreText")?.GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.FindWithTag("HighScoreText")?.GetComponent<TextMeshProUGUI>();
        UpdateScoreUI();
    }

    private void Update()
    {
        if (scoreMultiplier != 1f && Time.unscaledTime >= multiplierEndUnscaledTime)
        {
            scoreMultiplier = 1f;
        }
        if (!canTakeDamage && Time.unscaledTime >= canTakeDamageUnscaledTime)
        {
            canTakeDamage = true;
        }
        GameObject[] pinatas = GameObject.FindGameObjectsWithTag("Pinata");
        if (pinatas.Length == 0)
        {
            SpawnWave();
        }
        CheckPinatasOnSceneChange();
    }

    public void AddScore(float amount)
    {
        currentScore += amount * scoreMultiplier;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = currentScore.ToString();
        if (highScoreText != null)
            highScoreText.text = highScore.ToString();
    }

    public void SetScoreMultiplierTemp(float multiplier, float duration)
    {
        scoreMultiplier = multiplier;
        multiplierEndUnscaledTime = Time.unscaledTime + duration;
    }

    public void SetCanTakeDamageTemp(bool value, float duration)
    {
        canTakeDamage = value;
        if (!value)
        {
            canTakeDamageUnscaledTime = Time.unscaledTime + duration;
        }
    }

    public void ResetGame()
    {
        currentScore = 0;
        scoreMultiplier = 1f;
        canTakeDamage = true;
        pinataCount = 1;
        UpdateScoreUI();
    }

    private void SpawnWave()
    {
        for (int i = 0; i < pinataCount; i++)
        {
            float randomX = Random.Range(-10.3f, 10.3f);
            Vector3 spawnPos = new Vector3(randomX, 1.8f, 0f);

            GameObject pinata = Instantiate(pinataPrefab, spawnPos, Quaternion.identity);

            int direction = Random.Range(0, 2);

            //deze code kan beter
            if (direction == 0)
                pinata.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-4f, 0f);
        }
        
        pinataCount++;
    }

    private void CheckPinatasOnSceneChange()
    {
        if (SceneManager.GetActiveScene().name != "GameplayScene")
        {
            GameObject[] pinatas = GameObject.FindGameObjectsWithTag("Pinata");

            foreach (GameObject pinata in pinatas)
            {
                Destroy(pinata);
            }
        }
    }

    public void SetHardMode()
    {
        hardMode = true;
    }

    public void SetEasyMode()
    {
        hardMode = false;
    }
}