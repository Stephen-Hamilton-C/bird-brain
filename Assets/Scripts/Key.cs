using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public UnityEvent OnPickedUp = new();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.FindPlayer();
        if (!player) return;
        if (player.HasKey) return;
        
        player.HasKey = true;
        OnPickedUp.Invoke();
        Destroy(gameObject);
    }
}
