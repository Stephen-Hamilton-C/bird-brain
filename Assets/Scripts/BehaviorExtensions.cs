using UnityEngine;

public static class BehaviorExtensions
{
    public static Player FindPlayer(this Behaviour behaviour)
    {
        Player player = null;
        if (behaviour.CompareTag("Player"))
        {
            player = behaviour.GetComponent<Player>();
        }
        if (behaviour.CompareTag("PlayerCrouchCollider"))
        {
            player = behaviour.GetComponentInParent<Player>();
        }

        return player;
    }
}