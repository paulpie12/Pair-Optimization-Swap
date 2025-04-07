using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text scoreText;
    public GameObject gameOverText;

    public float asteroidSpeedMultiplier = 1f;
    private int score = 0;
    private bool gameEnded = false;

    private int nextSpeedThreshold = 50;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        if (gameEnded) return;

        score += amount;
        UpdateScoreUI();

        // Increase asteroid speed at each 50-point threshold
        if (score >= nextSpeedThreshold)
        {
            asteroidSpeedMultiplier += 0.25f; 
            nextSpeedThreshold += 50;
            Debug.Log("Asteroid speed increased! Multiplier: " + asteroidSpeedMultiplier);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void PlayerHit()
    {
        if (gameEnded) return;

        gameEnded = true;
        ClearScene();
        ShowFinalScore();
    }

    private void ClearScene()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj == this.gameObject) continue;
            if (obj.CompareTag("Background")) continue;
            if (obj.CompareTag("UI")) continue;
            if (obj.CompareTag("MainCamera")) continue;

            Destroy(obj);
        }
    }

    private void ShowFinalScore()
    {
        Debug.Log("Game Over! Final Score: " + score);

        if (scoreText != null)
        {
            scoreText.text = "Final Score: " + score;
        }

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }
}
