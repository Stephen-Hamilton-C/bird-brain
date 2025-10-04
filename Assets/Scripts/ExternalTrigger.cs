using UnityEngine;
using UnityEngine.Events;

public class ExternalTrigger : MonoBehaviour
{
    public UnityEvent<Collider2D> OnTriggerEnter;
    public UnityEvent<Collider2D> OnTriggerStay;
    public UnityEvent<Collider2D> OnTriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnter?.Invoke(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        OnTriggerStay?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnTriggerExit?.Invoke(other);
    }
}
