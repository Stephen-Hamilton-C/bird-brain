using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void Start() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        KillPlayer(other.FindPlayer());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        KillPlayer(other.collider.FindPlayer());
    }

    private void KillPlayer(Player player)
    {
        if(!enabled) return;
        if(!player) return;
        player.Kill();
    }
}
