using UnityEngine;

public class KeyRemover : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void RemoveKey()
    {
        _player.HasKey = false;
    }
}
