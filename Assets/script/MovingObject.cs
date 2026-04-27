using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _xBound = -10f;

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x < _xBound)
        {
            Destroy(gameObject);
        }
    }
}