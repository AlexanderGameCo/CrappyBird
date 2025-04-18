using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    private static UI _instance;
    public static UI Instance => _instance;
    public GameOverCanvas gameOverCanvas;
    public TMP_Text HUD_Score;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Prevent duplicate
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Reset()
    {
        gameOverCanvas.Hide();
        HUD_Score.text = "0";
        HUD_Score.gameObject.SetActive(true);   
    }
}
