using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public UnityEvent OnDoorOpened = new();
    
    private Player _player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var plr = other.FindPlayer();
        if (!plr) return;
        _player = plr;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.FindPlayer()) return;
        _player = null;
    }

    private void Update()
    {
        if (!_player) return;
        if(!_player.HasKey) return;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            OnDoorOpened.Invoke();
        }
    }
}
