using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.FindPlayer();
        if (!player) return;
        if (player.HasKey) return;
        
        player.HasKey = true;
        Destroy(gameObject);
    }
}
