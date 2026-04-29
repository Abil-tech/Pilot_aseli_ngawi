using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float xBound = -10f;

    private bool _gameStarted = false;

    public void StartGame()
    {
        _gameStarted = true;
    }

    private void Update()
    {
        if (!_gameStarted) return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }
}