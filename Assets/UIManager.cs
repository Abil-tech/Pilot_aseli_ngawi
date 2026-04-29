using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _restartButton;

    private int score = 0;

    private void Awake()
    {
        movement_player.OnScore += AddScore;
        movement_player.OnDeath += ShowRestart;
    }

    private void OnDestroy()
    {
        movement_player.OnScore -= AddScore;
        movement_player.OnDeath -= ShowRestart;
    }

    private void AddScore()
    {
        score++;
        _scoreText.text = score.ToString();
    }

    private void ShowRestart()
    {
        _restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}