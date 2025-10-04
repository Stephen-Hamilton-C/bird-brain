using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _minimumY = -11;
    
    public bool HasKey
    {
        get => _hasKey;
        set {
            _hasKey = value;
            OnHasKeyChanged.Invoke(_hasKey);
        }
    }
    private bool _hasKey;
    
    public UnityEvent<bool> OnHasKeyChanged = new();

    private void Update()
    {
        if (transform.position.y < _minimumY)
        {
            Kill();
        }
    }

    public void Kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}