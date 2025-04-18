using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public Player player;
    private int score = 0;
    private static int bestScore = 0;
    void Start()
    {
        Player.OnPlayerDied += onPlayerDied;
        Obstacle.OnObstacleDestroyed += onObstacleDestroyed;
    }

    void onPlayerDied()
    {
        bestScore = math.max(score, bestScore);
        Time.timeScale = 0f;
        UI.Instance.gameOverCanvas.Show(score, bestScore);
        UI.Instance.HUD_Score.gameObject.SetActive(false);
    }

    void onObstacleDestroyed()
    {
        score++;
        UI.Instance.HUD_Score.text = score.ToString();
    }


    public void Retry()
    {
        score = 0;
        Time.timeScale = 1f;
        UI.Instance.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Stops play mode
#else
        Application.Quit(); // Quits the built game
#endif
    }
}
