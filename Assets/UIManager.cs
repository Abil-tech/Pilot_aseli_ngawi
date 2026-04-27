using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;
    [SerializeField] private TMP_Text _score;

    private void Awake()
    {
         Debug.Log("UIManager AKTIF");
        
        movement_player.OnDeath += OnGameOver;
        movement_player.OnScore += HandleScore;
    }

    private void OnDestroy()
    {
        movement_player.OnDeath -= OnGameOver;
        movement_player.OnScore -= HandleScore;
    }

    private void HandleScore()
    {
        _score.text = (int.Parse(_score.text) + 1).ToString();
    }

    private void OnGameOver()
    {
        _playButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}