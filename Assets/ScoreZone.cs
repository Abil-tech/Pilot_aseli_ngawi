using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;

        if (collision.CompareTag("Player"))
        {
            triggered = true;

            GetComponent<Collider2D>().enabled = false;

            movement_player.TriggerScore();
        }
    }
}