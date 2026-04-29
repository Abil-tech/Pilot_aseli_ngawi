using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private float _yRange = 2f;

    private float _timer;
    private bool _gameStarted = false;

    public void StartGame()
    {
        _gameStarted = true;
    }

    private void Update()
    {
        if (!_gameStarted) return;

        _timer += Time.deltaTime;

        if (_timer > _spawnTime)
        {
            Spawn();
            _timer = 0;
        }
    }

    private void Spawn()
    {
        float yOffset = Random.Range(-_yRange, _yRange);

        GameObject pipe = Instantiate(
            _pipePrefab,
            new Vector2(transform.position.x, transform.position.y + yOffset),
            Quaternion.identity
        );

        // langsung aktifkan movement
        pipe.GetComponent<MovingObject>()?.StartGame();
    }
}