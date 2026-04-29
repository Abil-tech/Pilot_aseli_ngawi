using System;
using UnityEngine;

public class movement_player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _yBound;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _startText;

    private bool _isGameStarted = false;

    public static event Action OnDeath;
    public static event Action OnScore;

    private void Start()
    {
        Time.timeScale = 1f;
        _rigidbody.gravityScale = 0; // awal tidak jatuh
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 🚀 mulai game
            if (!_isGameStarted)
            {
                _isGameStarted = true;
                _rigidbody.gravityScale = 1;

                _spawner.StartGame();
                _startText.SetActive(false);
            }

            // 🐦 flap
            if (_rigidbody.position.y < _yBound)
            {
                Flap();
            }
        }
    }

    private void Flap()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDeath?.Invoke();
        Time.timeScale = 0f;
    }

    // wrapper biar aman dari error event
    public static void TriggerScore()
    {
        OnScore?.Invoke();
    }
}