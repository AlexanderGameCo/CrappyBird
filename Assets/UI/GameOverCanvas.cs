using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text BestScoreText;
    public Button RetryButton;
    public Button QuitButton;

    void Start()
    {
        Hide();
        RetryButton.onClick.AddListener(Retry_Click);
        QuitButton.onClick.AddListener(Quit_Click);
    }

    public void Show(int score, int bestScore)
    {
        gameObject.SetActive(true);
        ScoreText.text = score.ToString();
        BestScoreText.text = bestScore.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ScoreText.text = "0";
        BestScoreText.text = "0";
    }

    private void Retry_Click()
    {
        GameObject.Find("GameHandler").GetComponent<GameHandler>().Retry();
    }

    private void Quit_Click()
    {
        GameObject.Find("GameHandler").GetComponent<GameHandler>().Quit();
    }
}
