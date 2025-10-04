using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpeedConductor : MonoBehaviour
{
    [SerializeField] private PlatformDirector[] _platforms;

    private readonly Dictionary<PlatformDirector, float> _platformSpeeds = new();
    private CharacterController2D _controller;

    private void Start()
    {
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        foreach (var platform in _platforms)
        {
            _platformSpeeds[platform] = platform.Speed;
        }
    }

    private void Update()
    {
        foreach (var platform in _platforms)
        {
            platform.Speed = _controller.m_Grounded ? 0 : _platformSpeeds[platform];
        }
    }
}
