using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private float _yRange = 2f;

    private float _timer;

    private void Update()
    {
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

        Instantiate(
            _pipePrefab,
            new Vector2(transform.position.x, transform.position.y + yOffset),
            Quaternion.identity
        );
    }
}