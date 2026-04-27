using System;
using UnityEngine;

public class movement_player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _yBound;

    public static event Action OnDeath;
    public static event Action OnScore;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _rigidbody.position.y < _yBound)
        {
            Flap();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("KENA TRIGGER");

        if (collision.CompareTag("ScoreZone"))
        {
            Debug.Log("SCORE MASUK");
            OnScore?.Invoke();
        }   
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }
}