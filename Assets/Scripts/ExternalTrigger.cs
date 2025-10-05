using UnityEngine;
using UnityEngine.Events;

public class ExternalTrigger : MonoBehaviour
{
    public UnityEvent<Collider2D> OnTriggerEnter;
    public UnityEvent<Collider2D> OnTriggerStay;
    public UnityEvent<Collider2D> OnTriggerExit;
    
    public UnityEvent<Collision2D> OnColliderEnter;
    public UnityEvent<Collision2D> OnColliderStay;
    public UnityEvent<Collision2D> OnColliderExit;

    public UnityEvent<Player> OnPlayerEnterTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnter?.Invoke(other);
        var player = other.FindPlayer();
        if(player)
            OnPlayerEnterTrigger?.Invoke(player);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        OnTriggerStay?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnTriggerExit?.Invoke(other);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnColliderEnter?.Invoke(other);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        OnColliderStay?.Invoke(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        OnColliderExit?.Invoke(other);
    }
}
