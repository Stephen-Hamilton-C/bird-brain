using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public enum UpdateType
    {
        Update,
        FixedUpdate,
    }
    
    [SerializeField] private UpdateType _updateType = UpdateType.Update;
    [SerializeField] private float _waitTime = 1f;
    [SerializeField] private bool _autoStart;
    [SerializeField] private bool _oneShot;

    public UnityEvent OnTimeout = new();
    public float TimeLeft { get; private set; }

    private void Start()
    {
        if(_autoStart)
            StartTimer();
    }
    
    public void StartTimer()
    {
        if (TimeLeft > 0) return;
        TimeLeft = _waitTime;
    }

    public void StopTimer()
    {
        if (TimeLeft <= 0) return;
        TimeLeft = -1;
    }

    private void TimerTick(float deltaTime)
    {
        if (TimeLeft <= 0) return;
        
        TimeLeft -= deltaTime;
        if (TimeLeft <= 0)
        {
            OnTimeout?.Invoke();

            if (!_oneShot)
            {
                TimeLeft = _waitTime;
            }
        }
    }

    private void Update()
    {
        if (_updateType != UpdateType.Update) return;
        TimerTick(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(_updateType != UpdateType.FixedUpdate) return;
        TimerTick(Time.fixedDeltaTime);
    }
}
